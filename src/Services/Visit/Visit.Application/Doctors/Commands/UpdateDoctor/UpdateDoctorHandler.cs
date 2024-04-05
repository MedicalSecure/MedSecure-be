
//namespace Visit.Application.Doctors.Commands.UpdateDoctor;

//public class UpdateDoctorHandler (IApplicationDbContext dbContext) : ICommandHandler<UpdateDoctorCommand,UpdateDoctorResult>
//{
//    public async Task <UpdateDoctorResult>Handle (UpdateDoctorCommand command ,CancellationToken cancellationToken)
//    {
//        var doctorId = DoctorId.of(command.Doctor.Id);
//        var doctor= await dbContext.Doctors.FindAsync([doctorId],cancellationToken );
       
//        //verfier s'il exist doctor

//        if (doctor == null)
//        {
//            throw new DoctorNotFoundException (command.Doctor.Id);
//        }

//        //update doctor entity

//        UpdateDoctorWithNewValues(doctor, command.Doctor);
//        dbContext.Doctors.Update(doctor);

//        //save to database

//        await dbContext.SaveChangesAsync(cancellationToken);
//        return new UpdateDoctorResult(true);
//    }
//    private static void UpdateDoctorWithNewValues(Doctor doctor ,DoctorDto doctorDto)
//    {
//       doctor.Update(doctorDto.FirstName, doctorDto.LastName, doctorDto.DateOfBirth, doctorDto.Gender, doctorDto.Specialty);
//    }
//}
