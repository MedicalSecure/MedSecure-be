namespace Medication.Domain.ValueObjects;

public record DispenseId
{
    public Guid Value { get; }

    private DispenseId(Guid value) => Value = value;

    public static DispenseId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(DispenseId)} cannot be empty!");
        }
        return new DispenseId(value);
    }
}