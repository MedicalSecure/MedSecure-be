namespace Diet.Domain.ValueObjects;

public record MealItemId
{
    public Guid Value { get; }

    private MealItemId(Guid value) => Value = value;

    public static MealItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("MealItemId cannot be empty!");
        }
        return new MealItemId(value);
    }
}