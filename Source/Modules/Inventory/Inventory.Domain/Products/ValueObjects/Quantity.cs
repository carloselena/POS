using Blocks.Domain.Exceptions;
using Blocks.Domain.Guards;

namespace Blocks.Domain.ValueObjects;

public record Quantity
{
    public decimal Value { get; }

    public Quantity(decimal value)
    {
        Guard.AgainstNegativeDecimal(value, "cantidad");
        Guard.AgainstMoreThanTwoDecimals(value, "Cantidad");

        Value = value;
    }
}