namespace Pharmalink.Application.Dosages.Commands.UpdateDosage;

public class UpdateDosageHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateDosageCommand, UpdateDosageResult>
{
    public async Task<UpdateDosageResult> Handle(UpdateDosageCommand command, CancellationToken cancellationToken)
    {
        // Update Dosage entity from command object
        // save to database
        // return result
        var dosageId = DosageId.Of(command.Dosage.Id);
        var dosage = await dbContext.Dosages.FindAsync([dosageId], cancellationToken);

        if (dosage == null)
        {
            throw new DosageNotFoundException(command.Dosage.Id);
        }

        UpdateDosageWithNewValues(dosage, command.Dosage);

        dbContext.Dosages.Update(dosage);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDosageResult(true);
    }

    private static void UpdateDosageWithNewValues(Dosage dosage, DosageDto dosageDto)
    {
        dosage.Update(dosageDto.Code, dosageDto.Label);
    }
}
