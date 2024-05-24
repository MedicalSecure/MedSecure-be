namespace Medication.Domain.ValueObjects;


public record DosageId
{
    public Guid Value { get; }

    private DosageId(Guid value) => Value = value;

    public static DosageId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("DosageId cannot be empty!");
        }
        return new DosageId(value);
    }
}
