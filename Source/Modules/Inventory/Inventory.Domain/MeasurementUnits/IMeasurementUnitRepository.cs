using Blocks.Domain.Abstractions;

namespace Inventory.Domain.MeasurementUnits;

public interface IMeasurementUnitRepository : IGenericRepository<MeasurementUnit>
{
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> ExistsByAbbreviationAsync(string abbreviation, CancellationToken cancellationToken = default);
    Task<List<MeasurementUnit>> GetAllAsync(CancellationToken cancellationToken = default);
}