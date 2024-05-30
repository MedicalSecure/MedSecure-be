namespace Prescription.Domain.ValueObjects;

public record DiagnosisId
{
    public Guid Value { get; }

    private DiagnosisId(Guid value) => Value = value;

    public static DiagnosisId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(DiagnosisId)} cannot be empty!");
        }
        return new DiagnosisId(value);
    }
}