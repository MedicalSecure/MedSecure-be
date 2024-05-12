using BuildingBlocks.CQRS;
using FluentValidation;
using Medication.Application.Dtos;

namespace Medication.Application.Dosages.Commands.CreateDosage;

public record CreateDosageCommand(List<DosageDto> Dosages) : ICommand<CreateDosageResult>;
public record CreateDosageResult(List<Guid> IDs);
public class CreateDosageCommandValidator : AbstractValidator<CreateDosageCommand>
{

    public CreateDosageCommandValidator()
    {

    }

}
