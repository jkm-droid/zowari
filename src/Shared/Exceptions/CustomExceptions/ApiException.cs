using System.Net;
using Infrastructure.Shared.Exceptions.Models;

namespace Infrastructure.Shared.Exceptions.CustomExceptions;

public class ApiException : Exception
{
    public int StatusCode { get; set; }

    public List<ValidationError> Errors { get; set; }

    public string Details { get; set; }

    public ApiException(string message,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        string details = null,
        List<ValidationError> errors = null) :

        base(message)
    {
        StatusCode = (int)statusCode;
        Errors = errors;
        Details = details;
    }
}