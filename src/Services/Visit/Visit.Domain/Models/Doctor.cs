

namespace Visit.Domain.Models;

//    public class Doctor : Aggregate <DoctorId>
//{
//    public string FirstName { get; set; } = default!;
//    public string LastName { get; set;} = default!;
//    public DateTime DateOfBirth { get; set; } = default!;
//    public  Gender Gender { get; set; } = default!;

//    public Specialty Specialty { get; set; } = default!;

//    public static Doctor Create(DoctorId id , string firstName, string lastName, DateTime dateOfBirth , Gender gender , Specialty specialty)
//    {
//        var doctor = new Doctor {
//            Id = id,
//            FirstName = firstName,
//            LastName = lastName,
//            DateOfBirth = dateOfBirth,
//            Gender = gender,
//            Specialty = specialty
//        };
//        doctor.AddDomainEvent(new DoctorCreatedEvent(doctor));
//        return doctor;
//    }

//    public void Update(string firstName, string lastName, DateTime dateOfBirth, Gender gender, Specialty specialty)
//    {

//        FirstName = firstName;
//        LastName = lastName;
//        DateOfBirth = dateOfBirth;
//        Gender = gender;
//        Specialty = specialty;
      
//        AddDomainEvent(new DoctorUpdatedEvent(this));
       
//    }

//}
