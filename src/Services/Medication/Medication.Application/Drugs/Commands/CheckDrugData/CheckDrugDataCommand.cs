namespace Medication.Application.Drugs.Commands.CheckDrugData;

public record CheckDrugDataCommand(List<DrugDto> Drugs) : ICommand<CheckDrugDataResult>;
public record CheckDrugDataResult(List<DrugDto> DrugsChecked);
public class CheckDrugDataCommandValidator : AbstractValidator<CheckDrugDataCommand>
{
    public CheckDrugDataCommandValidator()
    {

    }

}
