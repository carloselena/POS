using Blocks.Domain.Guards;
using Blocks.Domain.ValueObjects;

namespace Inventory.Domain.MeasurementUnits.ValueObjects;

public sealed record Abbreviation : StringValueObject
{
    public Abbreviation(string value) : base(value)
    {
        Guard.AgainstNullOrWhiteSpace(value, nameof(Name));
        Guard.AgainstMaxLength(value, 3, nameof(Name));
    }
}