using Infrastructure.Shared.Abstractions;

namespace Infrastructure.Shared.Implementations;

public class CurrentDateProvider : ICurrentDateProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
    public DateTimeOffset NowUtc => DateTimeOffset.UtcNow;
}