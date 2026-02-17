using Blocks.Domain.Abstractions;
using Inventory.Domain.MeasurementUnits.ValueObjects;

namespace Inventory.Domain.MeasurementUnits;

public class MeasurementUnit : AggregateRoot
{
    public Name Name { get; private set; }
    public Abbreviation Abbreviation { get; private set; }
    
    private MeasurementUnit() { }

    public MeasurementUnit(Name name, Abbreviation abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
        Id = Guid.CreateVersion7();
    }

    public void Update(Name name, Abbreviation abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }
}