using Core.Shared.Exceptions;
using Inventory.Domain.ValueObjects;

namespace Inventory.Domain;

public class MeasurementUnit
{
    public int Id { get; private set; }
    public MeasurementUnitName Name { get; private set; }
    public Abbreviation Abbreviation { get; private set; }

    private MeasurementUnit() { }

    public MeasurementUnit(MeasurementUnitName name, Abbreviation abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }

    public void Update(MeasurementUnitName name, Abbreviation abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }
}