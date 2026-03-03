namespace Blocks.Domain.ValueObjects;

public record Money(decimal Amount, string Currency = "DOP");