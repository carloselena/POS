using Core.Shared.Exceptions;

namespace Inventory.Domain.ValueObjects;

public record Abbreviation
{
    public string Value { get; } = null!;

    private Abbreviation(){ }

    public Abbreviation(string abbreviation)
    {
        if (string.IsNullOrWhiteSpace(abbreviation))
            throw new DomainException("La abreviatura es obligatoria");

        if (abbreviation.Length > 3)
            throw new DomainException("La abreviatura no puede tener más de 3 caracteres");
        
        Value = abbreviation;
    }
}