namespace Diet.Domain.ValueObjects;

public record FoodId
{
    public Guid Value { get; }

    private FoodId(Guid value) => Value = value;

    public static FoodId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("FoodId cannot be empty!");
        }
        return new FoodId(value);
    }
}

