

namespace Visit.Domain.ValueObjects;

public record  VisitId
{
    public Guid Value { get; }
    private VisitId(Guid value) => Value = value;
    public static VisitId Of (Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("DietId cannot be empty!");
        }
        return new VisitId(value);
    }
}
