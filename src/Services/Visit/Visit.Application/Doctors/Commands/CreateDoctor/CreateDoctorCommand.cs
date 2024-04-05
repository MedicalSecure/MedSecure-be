
//namespace Visit.Application.Doctors.Commands.CreateDoctor;

//public record CreateDoctorCommand(DoctorDto Doctor) : ICommand<CreateDoctorResult>;

//public record CreateDoctorResult(Guid Id);

//public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
//{
//    public CreateDoctorCommandValidator()
//    {
//        RuleFor(x => x.Doctor.FirstName).NotEmpty().WithMessage("Doctor.FirstName is required");
//        RuleFor(x => x.Doctor.LastName).NotEmpty().WithMessage("Doctor.LastName is required");
//    }
//}
