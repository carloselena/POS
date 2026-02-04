using Core.Shared.Exceptions;

namespace Inventory.Domain.ValueObjects;

public record MeasurementUnitName
{
    public string Value { get; } = null!;

    private MeasurementUnitName(){ }

    public MeasurementUnitName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("El nombre es obligatorio");

        if (name.Length > 20)
            throw new DomainException("El nombre no tener más de 20 caracteres");
        
        Value = name;
    }
}