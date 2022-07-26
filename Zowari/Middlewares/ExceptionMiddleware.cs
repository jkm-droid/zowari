using System.Diagnostics;
using Infrastructure.Shared.Abstractions;
using Infrastructure.Shared.Exceptions.CustomExceptions;
using Infrastructure.Shared.Models;
using Newtonsoft.Json;
using Zowari.Extensions;

namespace Zowari.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;
    private readonly IViewRenderService _viewRenderService;
    
    public ExceptionMiddleware(RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env, IViewRenderService viewRenderService)
    {
        _next = next;
        _logger = logger;
        _env = env;
        _viewRenderService = viewRenderService;
    }
    
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Debugger.Break(); // Break if debugger is attached
    
            var errorMessage = ex.ToString();
            BaseErrorResponse errorResponse;
    
            switch (ex)
            {
                case ApiException apiException:
                    errorResponse = new BaseErrorResponse(apiException.StatusCode, new[] { apiException.Message }, apiException.Details) { Errors = apiException.Errors };
                    break;
    
                case InvalidModelStateException invalidModelStateException:
                    errorResponse = new BaseErrorResponse(StatusCodes.Status422UnprocessableEntity, invalidModelStateException.Errors, new[] { invalidModelStateException.Message });
                    break;
    
                case ArgumentNullException _:
                    errorResponse = new BaseErrorResponse(StatusCodes.Status400BadRequest, new[] { errorMessage }, string.Empty);
                    break;
    
                case ArgumentException _:
                    errorResponse = new BaseErrorResponse(StatusCodes.Status400BadRequest, new[] { errorMessage }, string.Empty);
                    break;
    
                case KeyNotFoundException _:
                    errorResponse = new BaseErrorResponse(StatusCodes.Status400BadRequest, new[] { errorMessage }, string.Empty);
                    break;
    
                default:
                    // unhandled error
                    _logger.LogError("Unhandled exception: {err})", JsonConvert.SerializeObject(ex));
                    var details = _env.IsDevelopment() ? ex.StackTrace : string.Empty;
                    errorResponse = new BaseErrorResponse(StatusCodes.Status500InternalServerError, new[] { $"An unhandled error occurred: {errorMessage}" }, details);
                    break;
            }
    
            string result;
            if (httpContext.Request.IsAjaxRequest())
            {
                var response = httpContext.Response;
                response.ContentType = "application/problem+json";
                response.StatusCode = errorResponse.StatusCode;
                result = JsonConvert.SerializeObject(errorResponse);
            }
            else
            {
                result = await _viewRenderService.RenderToStringAsync("/Views/Shared/Error.cshtml", errorResponse);
            }
    
            await httpContext.Response
                .WriteAsync(result)
                .ConfigureAwait(false);
        }
    }
}