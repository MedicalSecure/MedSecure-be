namespace Prescription.Domain.ValueObjects;
public record EquipmentId
{
    public Guid Value { get; }

    private EquipmentId(Guid value) => Value = value;

    public static EquipmentId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException(" EquipmentId cannot be empty!");
        }
        return new EquipmentId(value);
    }
}