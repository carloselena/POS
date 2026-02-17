using Inventory.Domain.MeasurementUnits;
using Inventory.Domain.MeasurementUnits.ValueObjects;

namespace Inventory.Tests.Domain.MeasurementUnits;

public class MeasurementUnitTests
{
    [Test]
    public void ShouldCreateMeasurementUnitWhenValuesAreValid()
    {
        const string nameValue = "Meter";
        const string abbreviationValue = "m";
        
        var name = new Name(nameValue);
        var abbreviation = new Abbreviation(abbreviationValue);
        
        var measurementUnit = new MeasurementUnit(name, abbreviation);
        
        Assert.That(measurementUnit.Name, Is.EqualTo(name));
        Assert.That(measurementUnit.Abbreviation, Is.EqualTo(abbreviation));
    }

    [Test]
    public void ShouldThrowWhenValuesAreInvalid()
    {
        Assert.Throws<ArgumentException>(() => new MeasurementUnit(new Name(string.Empty), new Abbreviation(string.Empty)));
    }
}