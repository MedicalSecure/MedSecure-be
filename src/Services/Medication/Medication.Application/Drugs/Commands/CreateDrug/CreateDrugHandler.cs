namespace Medication.Application.Drugs.Commands.CreateDrug;


public class CreateDrugHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDrugCommand, CreateDrugResult>
{
    public async Task<CreateDrugResult> Handle(CreateDrugCommand command, CancellationToken cancellationToken)
    {
        // Fetch existing drugs from the database
        // Update stock of existing drugs if they exist
        // create drug entity from command object
        // save to database
        // return result

        var drugsFromDB = await dbContext.Drugs.ToListAsync(cancellationToken);

        List<DrugDto> drugsCreated = new List<DrugDto>();

        foreach (var drug in command.Drugs)
        {
            var drugToUpdate = drugsFromDB.FirstOrDefault(d => d.Name == drug.Name &&
                                                               d.Dosage == drug.Dosage &&
                                                               d.Form == drug.Form &&
                                                               d.Code == drug.Code &&
                                                               d.Unit == drug.Unit &&
                                                               d.Description == drug.Description);


            if (drugToUpdate != null)
            {
                // Update medication Stock
                drugToUpdate.UpdateStock(drugToUpdate.Stock + drug.Stock);

                dbContext.Drugs.Update(drugToUpdate);
            }
            else
            {
                var newDrugToAdd = CreateNewDrug(drug);

                // medication not found in db : Add it
                if (newDrugToAdd != null)
                {
                    dbContext.Drugs.Add(newDrugToAdd);
                    drugsCreated.Add(drug);
                }
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateDrugResult(drugsCreated.Select(c => c.Id ?? Guid.NewGuid()).ToList());
    }

    private static Drug? CreateNewDrug(DrugDto drugDto)
    {
        var newDrug = Drug.Create(
            id: DrugId.Of(drugDto.Id ?? Guid.NewGuid()),
            name: drugDto.Name,
            dosage: drugDto.Dosage,
            form: drugDto.Form,
            code: drugDto.Code,
            unit: drugDto.Unit,
            description: drugDto.Description,
            expiredAt: drugDto.ExpiredAt,
            stock: drugDto.Stock,
            alertStock: drugDto.AlertStock,
            avrgStock: drugDto.AvrgStock,
            minStock: drugDto.MinStock,
            safetyStock: drugDto.SafetyStock,
            reservedStock: drugDto.ReservedStock,
            price: drugDto.Price
        );
        return newDrug;
    }

    private static List<Drug> CreateNewDrugs(List<DrugDto> drugsDto)
    {
        List<Drug> newDrugs = new List<Drug>();

        foreach (var drugDto in drugsDto)
        {
            var newDrug = CreateNewDrug(drugDto);

            if (newDrug != null)
            {
                newDrugs.Add(newDrug);
            }

        }

        return newDrugs;
    }
}
