namespace Waste.Domain.ValueObjects;

public record WasteId
{
    public Guid Value { get; }

    private WasteId(Guid value) => Value = value;

    public static WasteId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("WasteId cannot be empty!");
        }
        return new WasteId(value);
    }
}

