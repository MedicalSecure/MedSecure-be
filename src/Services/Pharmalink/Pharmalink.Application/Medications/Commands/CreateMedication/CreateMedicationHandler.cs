namespace Pharmalink.Application.Medications.Commands.CreateMedication;

public class CreateMedicationHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateMedicationCommand, CreateMedicationResult>
{
    public async Task<CreateMedicationResult> Handle(CreateMedicationCommand command, CancellationToken cancellationToken)
    {
        // Fetch existing medications from the database
        // Update existing medications if they exist
        // create medication entity from command object
        // save to database
        // return result

        var medicationsFromDB = await dbContext.Medications.ToListAsync(cancellationToken);
 
        List<MedicationDto> medicationsCreated = new List<MedicationDto>();

        foreach (var medication in command.Medications)
        {
            var criteria = medication.Name + medication.Dosage + medication.Form + medication.Code + medication.Unit + medication.Description;

            var medicationToUpdate = medicationsFromDB.FirstOrDefault(c => c.FullTextSearchIndex == criteria);

            if (medicationToUpdate != null)
            {
                // Update medication Stock
                medicationToUpdate.UpdateStock(medicationToUpdate.Stock + medication.Stock);

                dbContext.Medications.Update(medicationToUpdate);
            }
            else
            {
                var newMedicationToAdd = CreateNewMedication(medication);

                // medication not found in db : Add it
                if (newMedicationToAdd != null)
                {
                    dbContext.Medications.Add(newMedicationToAdd);
                    medicationsCreated.Add(medication);
                }
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateMedicationResult(medicationsCreated.Select(c => c.Id).ToList());
    }

    private static Medication? CreateNewMedication(MedicationDto medicationDto)
    {
        var newMedication = Medication.Create(
            id: MedicationId.Of(medicationDto.Id),
            name: medicationDto.Name,
            dosage: medicationDto.Dosage,
            form: medicationDto.Form,
            code: medicationDto.Code,
            unit: medicationDto.Unit,
            description: medicationDto.Description,
            expiredAt: medicationDto.ExpiredAt,
            stock: medicationDto.Stock,
            alertStock: medicationDto.AlertStock,
            avrgStock: medicationDto.AvrgStock,
            minStock: medicationDto.MinStock,
            safetyStock: medicationDto.SafetyStock,
            reservedStock: medicationDto.ReservedStock,
            price: medicationDto.Price
        );
        return newMedication;
    }

    private static List<Medication> CreateNewMedications(List<MedicationDto> medicationsDto)
    {
        List<Medication> newMedications = new List<Medication>();

        foreach (var medicationDto in medicationsDto)
        {
            var newMedication = CreateNewMedication(medicationDto);

            if (newMedication != null)
            {
                newMedications.Add(newMedication);
            }

        }

        return newMedications;
    }
}

