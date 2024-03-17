namespace Diet.Domain.ValueObjects;

public record MealId
{
    public Guid Value { get; }

    private MealId(Guid value) => Value = value;

    public static MealId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("MealId cannot be empty!");
        }
        return new MealId(value);
    }
}