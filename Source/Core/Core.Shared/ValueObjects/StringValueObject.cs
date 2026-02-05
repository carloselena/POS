namespace Core.Shared.ValueObjects;

public abstract record StringValueObject(string Value)
{
    public override string ToString() => Value;

    public static implicit operator string(StringValueObject obj) => obj.Value;
}