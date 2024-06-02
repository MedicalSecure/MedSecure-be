namespace Medication.Application.Dosages.Commands.UpdateDosage;


public record UpdateDosageCommand(DosageDto Dosage) : ICommand<UpdateDosageResult>;

public record UpdateDosageResult(bool IsSuccess);

public class UpdateDosageCommandValidator : AbstractValidator<UpdateDosageCommand>
{   
    public UpdateDosageCommandValidator()
    {
        RuleFor(d => d.Dosage.Id).NotEmpty().WithMessage("DosageId is required");
        RuleFor(d => d.Dosage.Code).NotEmpty().WithMessage("Dosage.Code is required");
    }
}
