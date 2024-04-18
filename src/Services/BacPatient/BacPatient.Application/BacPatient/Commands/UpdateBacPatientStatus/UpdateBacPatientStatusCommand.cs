namespace BacPatient.Application.BacPatient.Commands.UpdateBacPatientStatus;

public record UpdateBacPatientStatusCommand(Guid Id, StatusBP Status) : ICommand<UpdateBPResult>;

public record UpdateBPResult(bool IsSuccess);

public class UpdateBPCommandValidator : AbstractValidator<UpdateBacPatientStatusCommand>
{
}
