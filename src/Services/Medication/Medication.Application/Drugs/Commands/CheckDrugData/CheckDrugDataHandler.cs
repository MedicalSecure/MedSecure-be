using System.Text.RegularExpressions;

namespace Medication.Application.Drugs.Commands.CheckDrugData;

public class CheckDrugDataHandler(IApplicationDbContext dbContext) : ICommandHandler<CheckDrugDataCommand, CheckDrugDataResult>
{
    public async Task<CheckDrugDataResult> Handle(CheckDrugDataCommand command, CancellationToken cancellationToken)
    {

        var drugsFromDB = await dbContext.Drugs.ToListAsync(cancellationToken);

        var dosagesFromDB = await dbContext.Dosages.ToListAsync(cancellationToken);

        List<DrugDto> drugsChecked = new List<DrugDto>();

        foreach (var drug in command.Drugs)
        {
            bool isDrugExist = false;
            bool isDosageValid = false;

            var drugToCheck = drugsFromDB.FirstOrDefault(d => d.Name == drug.Name &&
                                                              d.Dosage == drug.Dosage &&
                                                              d.Form == drug.Form &&
                                                              d.Code == drug.Code &&
                                                              d.Unit == drug.Unit &&
                                                              d.Description == drug.Description);

            if (drugToCheck != null)
            {
                isDrugExist = true;

                foreach (var dosage in dosagesFromDB)
                {
                    if (dosage.Code != null)
                    {
                        // Use regex to separate the numeric part from the unit part
                        string combinedPattern = @"(\d+)\s*(.*)";
                        Match match = Regex.Match(drug.Dosage, combinedPattern);

                        if (match.Success && match.Groups[2].Value.Equals(dosage.Code))
                        {
                            isDosageValid = true;
                            break;
                        }
                        else
                        {
                            isDosageValid = false;
                        }
                    }
                }
            }
            else
            {
                foreach (var dosage in dosagesFromDB)
                {
                    if (dosage.Code != null)
                    {
                        // Use regex to separate the numeric part from the unit part
                        string combinedPattern = @"(\d+)\s*(.*)";
                        Match match = Regex.Match(drug.Dosage, combinedPattern);

                        if (match.Success && match.Groups[2].Value.Equals(dosage.Code))
                        {
                            isDosageValid = true;
                            break;
                        }
                        else
                        {
                            isDosageValid = false;
                        }
                    }
                }
            }
            drugsChecked.Add(new DrugDto(
                Id: drug.Id,
                Name: drug.Name,
                Dosage: drug.Dosage,
                Form: drug.Form,
                Code: drug.Code,
                Unit: drug.Unit,
                Description: drug.Description,
                ExpiredAt: drug.ExpiredAt,
                Stock: drug.Stock,
                AlertStock: drug.AlertStock,
                AvailableStock: drug.AvailableStock,
                AvrgStock: drug.AvrgStock,
                MinStock: drug.MinStock,
                SafetyStock: drug.SafetyStock,
                ReservedStock: drug.ReservedStock,
                Price: drug.Price,
                IsDrugExist: isDrugExist,
                IsDosageValid: isDosageValid
            ));

        }
        return new CheckDrugDataResult(drugsChecked);
    }
}
