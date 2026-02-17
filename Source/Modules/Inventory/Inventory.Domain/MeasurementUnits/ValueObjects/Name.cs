using Blocks.Domain.Guards;
using Blocks.Domain.ValueObjects;

namespace Inventory.Domain.MeasurementUnits.ValueObjects;

public sealed record Name : StringValueObject
{
    public Name(string value) : base(value)
    {
        Guard.AgainstNullOrWhiteSpace(value, nameof(Name));
        Guard.AgainstMaxLength(value, 20, nameof(Name));
    }
}