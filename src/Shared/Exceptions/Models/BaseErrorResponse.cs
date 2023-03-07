namespace Infrastructure.Shared.Exceptions.Models;

public class BaseErrorResponse
{
    public BaseErrorResponse()
    { }

    public BaseErrorResponse(int statusCode, IEnumerable<string> messages, string details = null)
    {
        StatusCode = statusCode;
        Messages = messages.ToList();
        Details = details ?? string.Empty;
    }

    public BaseErrorResponse(int statusCode, IEnumerable<ModelStateError> modelErrors, IEnumerable<string> messages)
    {
        if (modelErrors == null)
        {
            return;
        }

        var modelStateErrors = modelErrors.ToList();
        if (!modelStateErrors.Any())
        {
            Errors = null;
            return;
        }

        Messages = messages.ToList();
        StatusCode = statusCode;

        Errors = new List<ValidationError>();

        foreach (var res in modelStateErrors)
        {
            Errors.Add(new ValidationError
            {
                Message = res.Message,
                ControlId = res.Key,
                Id = res.Key
            });
        }
    }

    /// <summary>
    /// Succeeded
    /// </summary>
    /// <example>
    /// false
    /// </example>
    public bool Succeeded { get; set; } = false;

    /// <summary>
    /// Status code
    /// </summary>
    /// <example>
    /// 400
    /// </example>
    public int StatusCode { get; set; }

    /// <summary>
    /// Error messages
    /// </summary>
    /// <example>
    /// Model cannot be null
    /// </example>>
    public List<string> Messages { get; set; }

    /// <summary>
    /// Stack Trace of Exception
    /// </summary>
    /// <example>
    /// The field PaidAmount must be from 0 to 79228162514264337593543950335
    /// </example>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// List of errors
    /// </summary>
    public List<ValidationError> Errors { get; set; }
}