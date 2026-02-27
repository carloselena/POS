using Inventory.Domain.MeasurementUnits;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Repositories;

public class MeasurementUnitRepository(InventoryDbContext dbContext)
    : InventoryRepository<MeasurementUnit>(dbContext), IMeasurementUnitRepository
{
    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await Query().AnyAsync(mu => mu.MeasurementUnitName.Value == name, cancellationToken);
    }

    public async Task<bool> ExistsByAbbreviationAsync(string abbreviation, CancellationToken cancellationToken = default)
    {
        return await Query().AnyAsync(mu => mu.MeasurementUnitAbbreviation.Value == abbreviation, cancellationToken);
    }

    public async Task<List<MeasurementUnit>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Query().ToListAsync(cancellationToken);
    }
}