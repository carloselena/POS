using Core.Shared.Exceptions;

namespace Inventory.Domain;

public class MeasurementUnit
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }

    private MeasurementUnit() { }

    public MeasurementUnit(string name, string abbreviation)
    {
        ApplyBusinessRuleForName(name);
        ApplyBusinessRuleForAbbreviation(abbreviation);

        Name = name;
        Abbreviation = abbreviation;
    }

    public void Update(string name, string abbreviation)
    {
        ApplyBusinessRuleForName(name);
        ApplyBusinessRuleForAbbreviation(abbreviation);

        Name = name;
        Abbreviation = abbreviation;
    }
    private void ApplyBusinessRuleForName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("El nombre no puede estar vacío");

        if (name.Length > 20)
            throw new DomainException("El nombre no tener más de 20 caracteres");
    }
    private void ApplyBusinessRuleForAbbreviation(string abbreviation)
    {
        if (string.IsNullOrWhiteSpace(abbreviation))
            throw new DomainException("La abreviatura no puede estar vacía");

        if (abbreviation.Length > 3)
            throw new DomainException("La abreviatura no puede tener más de 3 caracteres");
    }
}