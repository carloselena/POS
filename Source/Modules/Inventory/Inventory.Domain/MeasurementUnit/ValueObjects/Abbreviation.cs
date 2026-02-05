using Core.Shared.Guards;
using Core.Shared.ValueObjects;

namespace Inventory.Domain.MeasurementUnit.ValueObjects;

public sealed record Abbreviation : StringValueObject
{
    public Abbreviation(string value) : base(value)
    {
        Guard.AgainstNullOrWhiteSpace(value, nameof(Name));
        Guard.AgainstMaxLength(value, 3, nameof(Name));
    }
}