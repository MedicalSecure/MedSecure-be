
namespace BacPatient.Domain.ValueObjects
{
    public record BPModelId
    {
        public Guid Value { get; }

    private BPModelId(Guid value) => Value = value;

    public static BPModelId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("BPModelId cannot be empty!");
        }
        return new BPModelId(value);
    }
    }
}
