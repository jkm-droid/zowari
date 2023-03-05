namespace Infrastructure.Shared.Abstractions;

public interface ICurrentDateProvider
{
    DateTimeOffset Now { get; }
    DateTimeOffset NowUtc { get; }
}