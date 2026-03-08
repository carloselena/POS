using Blocks.Domain.Exceptions;
using Blocks.Domain.Guards;

namespace Inventory.Domain.Products.ValueObjects;

public record Stock
{
    public decimal Value { get; }

    public Stock(decimal value = 0)
    {
        Guard.AgainstNegativeDecimal(value, "stock");
        Guard.AgainstMoreThanTwoDecimals(value, "Stock");
        
        Value = value;
    }

    internal Stock Increase(Quantity quantity)
        => new Stock(Value + quantity.Value);

    internal Stock Decrease(Quantity quantity)
    {
        return Value < quantity.Value ? throw new DomainException("Stock insuficiente") : new Stock(Value - quantity.Value);
    }
}