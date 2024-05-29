namespace Prescription.Domain.ValueObjects;

public record PrescriptionId
{
    public Guid Value { get; }

    private PrescriptionId(Guid value) => Value = value;

    public static PrescriptionId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(PrescriptionId)} cannot be empty!");
        }
        return new PrescriptionId(value);
    }
}