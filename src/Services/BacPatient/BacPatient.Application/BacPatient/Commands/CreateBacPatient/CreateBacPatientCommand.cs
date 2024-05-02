namespace BacPatient.Application.BPModels.Commands.CreateBacPatient;

public record CreateBacPatientCommand(BacPatientDto BacPatients) : ICommand<CreateBacPatientResult>;

public record CreateBacPatientResult(Guid Id);

public class CreateBacPatientCommandValidator : AbstractValidator<CreateBacPatientCommand>
{
    public CreateBacPatientCommandValidator()
    {
       
    }
}

