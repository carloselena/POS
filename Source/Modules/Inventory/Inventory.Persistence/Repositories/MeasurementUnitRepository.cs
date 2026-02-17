using Inventory.Domain.MeasurementUnits;

namespace Inventory.Persistence.Repositories;

public class MeasurementUnitRepository(InventoryDbContext dbContext)
    : InventoryRepository<MeasurementUnit>(dbContext)
{
    
}