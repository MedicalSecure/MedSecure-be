using Medication.Domain.Exceptions;

namespace Medication.Domain.ValueObjects;

public record DrugId
{
    public Guid Value { get; }

    private DrugId(Guid value) => Value = value;

    public static DrugId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("DrugId cannot be empty!");
        }
        return new DrugId(value);
    }
}