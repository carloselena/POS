using Inventory.Domain.Products;

namespace Inventory.Persistence.Repositories;

public class ProductRepository(InventoryDbContext dbContext)
    : InventoryRepository<Product>(dbContext), IProductRepository
{
    
}