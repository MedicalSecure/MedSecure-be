namespace BacPatient.Application.BPModels.Commands.CreateBacPatient;

public record CreateBacPatientCommand(BacPatientDto BacPatients) : ICommand<CreateBacPatientResult>;

public record CreateBacPatientResult(Guid Id);

public class CreateBacPatientCommandValidator : AbstractValidator<CreateBacPatientCommand>
{
    public CreateBacPatientCommandValidator()
    {
       
        RuleFor(x => x.BacPatients.Medicines).NotEmpty().WithMessage("Medcicnes is should not be empty");
    }
}

