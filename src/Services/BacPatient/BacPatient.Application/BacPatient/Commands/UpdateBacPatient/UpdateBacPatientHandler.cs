using BacPatient.Application.Extensions.SimpleBacPatientExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.BacPatient.Commands.UpdateBacPatient
{

    public class UpdateBacPatientHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateBacPatientCommand, UpdateBacPatientResult>
    {
        public async Task<UpdateBacPatientResult> Handle(UpdateBacPatientCommand command, CancellationToken cancellationToken)
        {
            // Update Diet entity from command object
            // save to database
            // return result
            var bacpatientid = BacPatienId.Of(command.BacPatient.Id);
            var bacpatient = await dbContext.BacPatients.FindAsync([bacpatientid], cancellationToken);
            UpdateBacPatientNewValues(bacpatient, command.BacPatient);
            dbContext.BacPatients.Update(bacpatient);





            //create new activity
            Guid createdBy = Guid.NewGuid();
            var newActivity = Domain.Models.Activity.Create(createdBy, $"Update  {nameof(BacPatient)}", "Tiss Rahma");
            dbContext.Activities.Add(newActivity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateBacPatientResult(true);
        }

        private static void UpdateBacPatientNewValues(Domain.Models.BacPatient bacPatient, BacPatientDto bacPatientDto)
        {
            bacPatient.Update(
                bacPatientDto.Prescription.ToPrescriptionEntity(),
                bacPatientDto.NurseId,
                bacPatientDto.Served,
                bacPatientDto.ToServe,
                bacPatientDto.Status);
        }
    }
}
