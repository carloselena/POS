using Inventory.Domain.MeasurementUnits.ValueObjects;

namespace Inventory.Tests.Domain.MeasurementUnits.ValueObjects;

public class AbbreviationTests
{
    [Test]
    public void ShouldCreateAbbreviationWhenValueIsValid()
    {
        const string value = "m";
        var name = new Abbreviation(value);
        Assert.That(name.Value, Is.EqualTo(value));
    }

    [Test]
    public void ShouldThrowWhenValueIsNull()
    {
        Assert.Throws<ArgumentException>(() => new Abbreviation(null!));
    }

    [Test]
    public void ShouldThrowWhenValueIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new Abbreviation(string.Empty));
    }
    
    [Test]
    public void ShouldThrowWhenValueIsWhiteSpace()
    {
        Assert.Throws<ArgumentException>(() => new Abbreviation("   "));
    }
    
    [Test]
    public void ShouldThrowWhenValueExceedsMaxLength()
    {
        var value = new string('A', 4);

        Assert.Throws<ArgumentException>(() => new Abbreviation(value));
    }
    
    [Test]
    public void ShouldAllowValueWithExactly20Characters()
    {
        var value = new string('A', 3);

        var name = new Abbreviation(value);

        Assert.That(name.Value, Is.EqualTo(value));
    }
}