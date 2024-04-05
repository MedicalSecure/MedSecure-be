

//using Visit.Application.Doctors.Commands.UpdateDoctor;

//namespace Visit.Application.Doctors.Commands.DeleteDoctor;

//public class DeleteDoctorHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteDoctorCommand, DeleteDoctorResult>
//{
//    public async Task<DeleteDoctorResult> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
//    {
//        var doctorId = DoctorId.of(command.Doctor.Id);
//        var doctor = await dbContext.Doctors.FindAsync([doctorId], cancellationToken);

//        //verfier s'il exist doctor

//        if (doctor == null)
//        {
//            throw new DoctorNotFoundException(command.Doctor.Id);
//        }
//        //supprimer le medecin
//        dbContext.Doctors.Remove(doctor);

//        //save to database
//        await dbContext.SaveChangesAsync(cancellationToken);
//        return new DeleteDoctorResult(true);


//    }

//}


