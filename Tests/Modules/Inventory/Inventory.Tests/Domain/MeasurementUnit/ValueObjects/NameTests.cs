using Inventory.Domain.MeasurementUnit.ValueObjects;

namespace Inventory.Tests.Domain.MeasurementUnit.ValueObjects;

public class NameTests
{
    [Test]
    public void ShouldCreateNameWhenValueIsValid()
    {
        const string value = "Meter";
        var name = new Name(value);
        Assert.That(name.Value, Is.EqualTo(value));
    }

    [Test]
    public void ShouldThrowWhenValueIsNull()
    {
        Assert.Throws<ArgumentException>(() => new Name(null!));
    }

    [Test]
    public void ShouldThrowWhenValueIsEmpty()
    {
        Assert.Throws<ArgumentException>(() => new Name(string.Empty));
    }
    
    [Test]
    public void ShouldThrowWhenValueIsWhiteSpace()
    {
        Assert.Throws<ArgumentException>(() => new Name("   "));
    }
    
    [Test]
    public void ShouldThrowWhenValueExceedsMaxLength()
    {
        var value = new string('A', 21);

        Assert.Throws<ArgumentException>(() => new Name(value));
    }
    
    [Test]
    public void ShouldAllowValueWithExactly20Characters()
    {
        var value = new string('A', 20);

        var name = new Name(value);

        Assert.That(name.Value, Is.EqualTo(value));
    }
}