using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence;

public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
{
    
}