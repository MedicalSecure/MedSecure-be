namespace Prescription.Domain.ValueObjects;

public record SymptomId
{
    public Guid Value { get; }

    private SymptomId(Guid value) => Value = value;

    public static SymptomId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(SymptomId)} cannot be empty!");
        }
        return new SymptomId(value);
    }
}