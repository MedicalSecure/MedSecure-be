namespace Medication.Domain.ValueObjects;

public record ValidationId
{
    public Guid Value { get; }

    private ValidationId(Guid value) => Value = value;

    public static ValidationId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ValidationId cannot be empty!");
        }
        return new ValidationId(value);
    }
}