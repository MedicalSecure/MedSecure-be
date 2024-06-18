using BuildingBlocks.Messaging.Events.Drugs;
using MassTransit;
using Medication.Application.Drugs.Commands.CreateDrug;
using Medication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medication.Application.Validations.Commands.UpdateValidation
{
    public class UpdateValidationHandler(IApplicationDbContext dbContext, IPublishEndpoint publisher) : ICommandHandler<UpdateValidationCommand, UpdateValidationResult>
    {
        public async Task<UpdateValidationResult> Handle(UpdateValidationCommand command, CancellationToken cancellationToken)
        {
            var isPending = command.Validation.Status == ValidationStatus.Pending;
            if (isPending)
                throw new InvalidOperationException($"The New Status Is Pending. Please Accept Or Reject The Validation!");
            var validationId = ValidationId.Of(command.Validation.Id);

            var validation = await dbContext.Validations.FirstOrDefaultAsync(v => v.Id == validationId)
                ?? throw new NotFoundException($"Validation with Id: {validationId} not found!");
            var isOldValidationPending = validation.Status == ValidationStatus.Pending;
            if (isOldValidationPending == false)
                throw new InvalidOperationException($"The Old Status Is Not Pending. The Validation Is Read Only!");

            var posologies = await dbContext.Posologies
                .Where(p => p.ValidationId == validationId)
                .Include(p => p.Drug)
                .Include(p => p.Dispenses)
                .ToListAsync(cancellationToken);

            var isRejected = command.Validation.Status == ValidationStatus.Rejected;

            foreach (var posology in validation.Posologies)
            {
                var drug = posology.Drug ?? throw new NotFoundException($"Drug with id: {posology.DrugId} not found");
                int quantityNeeded = 0;


                foreach (var dispense in posology.Dispenses)
                {
                    var dispenseBeforeMeal = dispense.BeforeMeal ?? 0;
                    var dispenseAfterMeal = dispense.AfterMeal ?? 0;

                    quantityNeeded += dispenseBeforeMeal + dispenseAfterMeal;
                }
                if (isRejected)
                {
                    drug.FreeReservedStock(quantityNeeded);
                }
                else
                {
                    drug.UpdateStockAfterValidation(quantityNeeded);
                }
            }
            Guid createdBy = command.Validation.PharmacistId;
            string pharmacistName = command.Validation.PharmacistName ?? "Pharmacist x";

            string? notesforEvent = null;
            if (isRejected)
            {
                string notes = command.Validation.Notes ?? throw new ArgumentNullException($"Rejection must have a Note");
                notesforEvent=notes;
                validation.Reject(createdBy, notes, pharmacistName);
                // Add Activity
                var newActivity = Activity.Create(createdBy, $"Rejected a Prescription", pharmacistName);
                dbContext.Activities.Add(newActivity);
            }
            else
            {
                string notes = command.Validation.Notes ?? "No notes";
                notesforEvent = notes;
                validation.Validate(createdBy, notes, pharmacistName);
                // Add Activity
                var newActivity = Activity.Create(createdBy, $"Validated a Prescription", pharmacistName);
                dbContext.Activities.Add(newActivity);
            }

            dbContext.Validations.Update(validation);
            await dbContext.SaveChangesAsync(cancellationToken);

            var newEvent = new PrescriptionValidationSharedEvent(
                presId: validation.PrescriptionId,
                pharmacistId: createdBy,
                pharmacistName:pharmacistName,
                unitCareJson:validation.UnitCareJson,
                validated: !isRejected,
                notes: notesforEvent
                );
            await publisher.Publish(newEvent);

            return new UpdateValidationResult(validation.ToValidationDto());
        }
    }
}

