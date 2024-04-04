namespace BacPatient.Application.BPModels.Commands.UpdateDiet;

public class UpdateBPHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateBPCommand, UpdateBPResult>
{
    public async Task<UpdateBPResult> Handle(UpdateBPCommand command, CancellationToken cancellationToken)
    {
        // Update Diet entity from command object
        // save to database
        // return result
        var BPid = BPModelId.Of(command.BPModel.Id);
        var bp = await dbContext.BacPatients.FindAsync([BPid], cancellationToken);

        if (bp == null)
        {
            throw new BPNotFoundException(command.BPModel.Id);
        }

        UpdateBpWithNewValues(bp, command.BPModel);

        dbContext.BacPatients.Update(bp);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateBPResult(true);
    }

    private static void UpdateBpWithNewValues(Domain.Models.BPModel bPModel, BPModelDto bPDto)
    {
        bPModel.Update(PatientId.Of(bPDto.PatientId), RoomId.Of(bPDto.RoomId),UnitCareId.Of(bPDto.UnitCareId),bPDto.Bed , bPDto.ServingDate,bPDto.Served,bPDto.ToServe,bPDto.Status);
    }
}