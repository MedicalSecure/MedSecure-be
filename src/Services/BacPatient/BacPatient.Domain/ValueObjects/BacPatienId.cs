
namespace BacPatient.Domain.ValueObjects
{
    public record BacPatienId
    {
        public Guid Value { get; }

    private BacPatienId(Guid value) => Value = value;

    public static BacPatienId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("BPModelId cannot be empty!");
        }
        return new BacPatienId(value);
    }
    }
}
