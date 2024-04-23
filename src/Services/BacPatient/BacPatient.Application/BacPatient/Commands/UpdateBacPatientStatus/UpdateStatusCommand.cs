namespace BacPatient.Application.BacPatient.Commands.UpdateBacPatientStatus;

public record UpdateStatusCommand(Guid Id, StatusBP Status) : ICommand<UpdateStatusResult>;

public record UpdateStatusResult(bool IsSuccess);

public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
{
}
