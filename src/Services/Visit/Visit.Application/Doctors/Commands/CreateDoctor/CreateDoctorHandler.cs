

//using Visit.Domain.Enums;
//using Visit.Domain.Models;
//using Visit.Domain.ValueObjects;

//namespace Visit.Application.Doctors.Commands.CreateDoctor;

//public class CreateDoctorHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDoctorCommand, CreateDoctorResult>
//{
//    public async Task <CreateDoctorResult> Handle(CreateDoctorCommand command , CancellationToken cancellationToken)
//    {
//        var doctor = CreateNewDoctor(command.Doctor);
//        dbContext.Doctors.Add(doctor);
//        await dbContext.SaveChangesAsync(cancellationToken);
//        return new CreateDoctorResult(doctor.Id.Value);

//    }
//    private static Doctor CreateNewDoctor (DoctorDto doctorDto)
//    {
//        var newdoctor = Doctor.Create(
//            id: DoctorId.of(Guid.NewGuid()),
//            firstName: doctorDto.FirstName,
//            lastName: doctorDto.LastName,
//            dateOfBirth: doctorDto.DateOfBirth,
//            gender: doctorDto.Gender,
//            specialty :doctorDto.Specialty
//            );
//        return ( newdoctor);
//    }
//}
