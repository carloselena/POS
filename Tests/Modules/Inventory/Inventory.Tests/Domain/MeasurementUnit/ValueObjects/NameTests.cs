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
}