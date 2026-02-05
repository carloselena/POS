namespace Core.Shared.Abstractions;

public interface IAggregateRoot<TId>
    where TId : notnull
{
    TId Id { get; }
    
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    
    void ClearDomainEvents();
}