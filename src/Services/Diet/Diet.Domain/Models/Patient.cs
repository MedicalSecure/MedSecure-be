namespace Diet.Domain.Models;

public class Patient : Entity<PatientId>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public Gender Gender { get; set; } = default!;

    public static Patient Create(string firstName,string lastName, DateTime dateOfBirth, Gender gender)
    {
        return new Patient
        {
            Id = PatientId.Of(Guid.NewGuid()),
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Gender = gender
        };
    }

    public void Update(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }
}
