namespace Medication.Domain.ValueObjects;

public record PosologyId
{
    public Guid Value { get; }

    private PosologyId(Guid value) => Value = value;

    public static PosologyId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("PosologySummaryId cannot be empty!");
        }
        return new PosologyId(value);
    }
}