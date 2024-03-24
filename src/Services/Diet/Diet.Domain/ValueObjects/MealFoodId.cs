namespace Diet.Domain.ValueObjects;

public record MealFoodId
{
    public Guid Value { get; }

    private MealFoodId(Guid value) => Value = value;

    public static MealFoodId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("MealFoodId cannot be empty!");
        }
        return new MealFoodId(value);
    }
}