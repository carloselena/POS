using Core.Shared.Guards;
using Core.Shared.ValueObjects;

namespace Inventory.Domain.MeasurementUnit.ValueObjects;

public sealed record Name : StringValueObject
{
    public Name(string value) : base(value)
    {
        Guard.AgainstNullOrWhiteSpace(value, nameof(Name));
        Guard.AgainstMaxLength(value, 20, nameof(Name));
    }
}