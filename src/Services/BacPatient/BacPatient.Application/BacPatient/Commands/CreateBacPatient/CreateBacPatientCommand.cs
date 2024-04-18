namespace BacPatient.Application.BPModels.Commands.CreateBacPatient;

public record CreateBacPatientCommand(BacPatientDto BacPatients) : ICommand<CreateBacPatientResult>;

public record CreateBacPatientResult(Guid Id);

public class CreateBacPatientCommandValidator : AbstractValidator<CreateBacPatientCommand>
{
    public CreateBacPatientCommandValidator()
    {
        RuleFor(x => x.BacPatients.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.BacPatients.RoomId).NotEmpty().WithMessage("RoomId is required");
        RuleFor(x => x.BacPatients.UnitCareId).NotEmpty().WithMessage("UnitCareId is required");
        RuleFor(x => x.BacPatients.Medicines).NotEmpty().WithMessage("Medcicnes is should not be empty");
    }
}

