using System.Net;
using Infrastructure.Shared.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class DatabaseTransactionExtensions
{
    public static async Task<IResult> HandleException(this DbUpdateException exception)
    {
        var message = $"{exception.Message} {exception.InnerException?.Message}";
        /*if (message.Contains("IX_OptInRequests_RequestId") || message.Contains("IX_Subscriptions_RequestId"))
            return await Result.FailAsync(Errors.OptIn.RequestAlreadyProcessed(), HttpStatusCode.Conflict);*/

        return await Result.FailAsync($"{exception.Message}", HttpStatusCode.InternalServerError);
    }
}