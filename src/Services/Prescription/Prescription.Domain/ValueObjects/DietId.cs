namespace Prescription.Domain.ValueObjects;

public record DietId
{
    public Guid Value { get; }

    private DietId(Guid value) => Value = value;

    public static DietId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("DietId cannot be empty!");
        }
        return new DietId(value);
    }

    public static DietId? OfNullable(Guid? value)
    {
        if (!value.HasValue)
        {
            return null;
        }

        if (value.Value == Guid.Empty)
        {
            throw new DomainException("DietId cannot be empty!");
        }

        return new DietId(value.Value);
    }
}