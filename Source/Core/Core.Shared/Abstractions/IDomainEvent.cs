namespace Core.Shared.Abstractions;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}