


using System.Text.Json.Serialization;

namespace Visit.Domain.ValueObjects;
public record PatientId
{
    
    public Guid Value { get; }

    // [JsonConstructor] error: deserialization of value objects
    // The issue arises because these value objects (PatientId and DoctorId) lack a parameterless constructor.
    // When ASP.NET Core attempts to deserialize the request, it fails to instantiate these value objects because it can't find a parameterless constructor.
    // To resolve this issue, you can either add a parameterless constructor to your value objects (PatientId and DoctorId) or add a constructor annotated with JsonConstructorAttribute.
    private PatientId(Guid value) => Value = value;

    public static PatientId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("PatientId cannot be empty!");
        }
        return new PatientId(value);
    }
}