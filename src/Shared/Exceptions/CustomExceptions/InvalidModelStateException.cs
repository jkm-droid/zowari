using Infrastructure.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Shared.Exceptions.CustomExceptions;

public class InvalidModelStateException : Exception
{
    public int StatusCode { get; set; } = StatusCodes.Status422UnprocessableEntity;
    public IEnumerable<ModelStateError> Errors { get; set; }

    public InvalidModelStateException(IEnumerable<ModelStateError> errors, string message = "Invalid request object. Please correct the specified errors and try again.") : base(message)
    {
        Errors = errors;
    }
}