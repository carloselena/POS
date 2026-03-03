using Blocks.Domain.Abstractions;
using Blocks.Domain.Exceptions;
using Blocks.Domain.Guards;
using Blocks.Domain.ValueObjects;
using Inventory.Domain.Products.ValueObjects;

namespace Inventory.Domain.Products;

public class Product : AggregateRoot
{
    public BarCode BarCode { get; private set; }
    public string Description { get; private set; }
    public Money Cost { get; private set; }
    public Money Price { get; private set; }
    public Quantity WholesaleQuantity { get; private set; }
    public Money WholesalePrice { get; private set; }
    public Stock Stock { get; private set; }
    public decimal MinStock { get; private set; }

    public Product(BarCode barCode, string description, Money cost, Money price, Quantity wholesaleQuantity,
        Money wholesalePrice, Stock stock, decimal minStock = 0)
    {
        Guard.AgainstNullOrWhiteSpace(description, nameof(description));

        if (cost.Amount >= price.Amount)
            throw new DomainException("El precio debe ser mayor que el costo");

        if (wholesalePrice.Amount > price.Amount)
            throw new DomainException("El precio al por mayor no puede ser mayor al precio regular");
        
        BarCode = barCode;
        Description = description;
        Cost = cost;
        Price = price;
        WholesaleQuantity = wholesaleQuantity;
        WholesalePrice = wholesalePrice;
        Stock = stock;
        MinStock = minStock;
        Id = Guid.CreateVersion7();
    }
}