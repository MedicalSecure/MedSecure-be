namespace Prescription.Domain.ValueObjects;

public record RegisterId
{
    public Guid Value { get; }

    private RegisterId(Guid value) => Value = value;

    public static RegisterId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException($"{nameof(RegisterId)} cannot be empty!");
        }
        return new RegisterId(value);
    }
}