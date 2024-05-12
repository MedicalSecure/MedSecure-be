using BuildingBlocks.CQRS;
using FluentValidation;

namespace Medication.Application.Dosages.Commands.DeleteDosage;

public record DeleteDosageCommand(Guid Id) : ICommand<DeleteDosageResult>;

public record DeleteDosageResult(bool IsSuccess);
public class DeleteDosageCommandValidator : AbstractValidator<DeleteDosageCommand>
{
    public DeleteDosageCommandValidator()
    {
        RuleFor(d => d.Id).NotEmpty().WithMessage("DosageId is required ");
    }

}
