

namespace Visit.Domain.Models;

public class Patient : Aggregate<PatientId>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public Gender Gender { get; set; } = default!;

    public static Patient Create(PatientId id, string firstName, string lastName, DateTime dateOfBirth, Gender gender)
    {
        var patient = new Patient
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Gender = gender
        };

        patient.AddDomainEvent(new PatientCreatedEvent(patient));

        return patient;
    }

    public void Update(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;

        AddDomainEvent(new PatientUpdatedEvent(this));
    }
}
