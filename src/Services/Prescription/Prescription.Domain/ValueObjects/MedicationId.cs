namespace Prescription.Domain.ValueObjects;
public record MedicationId
{
    public Guid Value { get; }

    private MedicationId(Guid value) => Value = value;

    public static MedicationId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(MedicationId)} cannot be empty!");
        }
        return new MedicationId(value);
    }
}