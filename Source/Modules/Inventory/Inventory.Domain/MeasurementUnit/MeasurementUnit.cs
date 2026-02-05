using Core.Shared.Abstractions;
using Inventory.Domain.MeasurementUnit.ValueObjects;

namespace Inventory.Domain.MeasurementUnit;

public class MeasurementUnit : AggregateRoot<int>
{
    public Name Name { get; private set; }
    public Abbreviation Abbreviation { get; private set; }
    
    private MeasurementUnit() { }

    public MeasurementUnit(Name name, Abbreviation abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }

    public void Update(Name name, Abbreviation abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }
}