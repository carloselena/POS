using Inventory.Domain.MeasurementUnit;

namespace Inventory.Persistence.Repositories;

public class MeasurementUnitRepository(InventoryDbContext dbContext)
    : InventoryRepository<MeasurementUnit>(dbContext)
{
    
}