using BuildingBlocks.CQRS;
using Medication.Application.Data;
using Medication.Application.Exceptions;
using Medication.Domain.ValueObjects;

namespace Medication.Application.Dosages.Commands.DeleteDosage;

public class DeleteDosageHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteDosageCommand, DeleteDosageResult>
{
    public async Task<DeleteDosageResult> Handle(DeleteDosageCommand command, CancellationToken cancellationToken)
    {
        // Delete Dosage entity from command object
        // save to database
        // return result
        var dosageId = DosageId.Of(command.Id);
        var dosage = await dbContext.Dosages.FindAsync([dosageId], cancellationToken);

        if (dosage == null)
        {
            throw new DosageNotFoundException(command.Id);
        }

        dbContext.Dosages.Remove(dosage);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteDosageResult(true);
    }

}
