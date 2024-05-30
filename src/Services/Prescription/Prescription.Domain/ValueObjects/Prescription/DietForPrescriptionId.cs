namespace Prescription.Domain.ValueObjects;

public record DietForPrescriptionId
{
    public Guid Value { get; }

    private DietForPrescriptionId(Guid value) => Value = value;

    public static DietForPrescriptionId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(DietForPrescriptionId)} cannot be empty!");
        }
        return new DietForPrescriptionId(value);
    }
}