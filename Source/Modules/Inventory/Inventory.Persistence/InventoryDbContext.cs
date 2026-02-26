using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence;

public class InventoryDbContext(DbContextOptions<InventoryDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}