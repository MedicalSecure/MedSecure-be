namespace Waste.Domain.ValueObjects;

public record WasteItemId
{
    public Guid Value { get; }

    private WasteItemId(Guid value) => Value = value;

    public static WasteItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value); 
        if(value == Guid.Empty)
        {
            throw new DomainException("WasteItemId cannot be empty!");
        }
        return new WasteItemId(value);
    }
}
