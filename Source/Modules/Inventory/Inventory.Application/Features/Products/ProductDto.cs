namespace Inventory.Application.Features.Products;

public record ProductDto(
    Guid Id,
    string BarCode,
    string Description,
    decimal Cost,
    decimal Price,
    decimal WholesaleQuantity,
    decimal WholesalePrice,
    decimal Stock,
    decimal MinStock
);