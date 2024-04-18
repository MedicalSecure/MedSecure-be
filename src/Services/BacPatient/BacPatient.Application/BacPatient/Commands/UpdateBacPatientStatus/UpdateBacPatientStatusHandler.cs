﻿


using BacPatient.Application.BacPatient.Commands.UpdateBacPatientStatus;

namespace BacPatient.Application.BacPatient.Commands.AddNote
{

    public class UpdateBacPatientStatusHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<UpdateBacPatientStatusCommand, UpdateBPResult>
    {
        public async Task<UpdateBPResult> Handle(UpdateBacPatientStatusCommand command, CancellationToken cancellationToken)
        {
            var BPid = BacPatienId.Of(command.Id);
            var bacPatients = await dbContext.BacPatients.FindAsync([BPid], cancellationToken);
            if (bacPatients == null)
            {
                throw new BPNotFoundException(command.Id);
            }

            UpdateBacPatientStatusWithNewValues(bacPatients, command.Status);

            dbContext.BacPatients.Update(bacPatients);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateBPResult(true);
        }

        private static void UpdateBacPatientStatusWithNewValues(Domain.Models.BacPatient bPModel, StatusBP status)
        {
            bPModel.Update(status);
        }
    }
}
