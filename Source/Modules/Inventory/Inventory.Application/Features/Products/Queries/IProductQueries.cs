namespace Inventory.Application.Features.Products.Queries;

public interface IProductQueries
{
    Task<List<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
}