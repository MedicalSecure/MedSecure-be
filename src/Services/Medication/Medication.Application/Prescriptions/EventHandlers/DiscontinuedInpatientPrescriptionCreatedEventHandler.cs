using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Medication.Application.Hubs;
using Medication.Application.Hubs.Abstractions;
using Medication.Domain.Enums;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Medication.Application.Prescriptions.EventHandlers
{
    public class DiscontinuedInpatientPrescriptionCreatedEventHandler(IApplicationDbContext _dbContext) : IConsumer<DiscontinuedInpatientPrescriptionSharedEvent>
    {
        public async Task Consume(ConsumeContext<DiscontinuedInpatientPrescriptionSharedEvent> context)
        {
            var p = context.Message;
            var prescriptionId = p.Id;

            var validation = await _dbContext.Validations
                .FirstOrDefaultAsync(v => v.PrescriptionId == prescriptionId);

            if (validation == null)
            {
                Console.WriteLine($"Validation with Prescription Id: {prescriptionId} not found!");
                return;
            }
            var validationId = validation.Id;

            var isPending = validation.Status == ValidationStatus.Pending;
            if (isPending == false)
            {
                Console.WriteLine($"The Validation is not pending : {validation.Status}. Cant Discontinue/Cancel it!");
                return;
            }

            var posologies = await _dbContext.Posologies
                .Where(p => p.ValidationId == validationId)
                .Include(p => p.Drug)
                .Include(p => p.Dispenses)
                .ToListAsync(CancellationToken.None);

            //continue preparing the event

            foreach (var posology in validation.Posologies)
            {
                var drug = posology.Drug;
                if (drug == null)
                {
                    Console.WriteLine($"Drug not found posology id : {posology.Id.Value}. Cant Free the reserved stock!");
                    continue;
                }

                int quantityToFree = 0;

                foreach (var dispense in posology.Dispenses)
                {
                    var dispenseBeforeMeal = dispense.BeforeMeal ?? 0;
                    var dispenseAfterMeal = dispense.AfterMeal ?? 0;

                    quantityToFree += dispenseBeforeMeal + dispenseAfterMeal;
                }
                drug.FreeReservedStock(quantityToFree);
            }
            Guid createdBy = p.DoctorId;
            string doctorName = "System";
            try
            {
                validation.Cancel(createdBy, doctorName);
                _dbContext.Validations.Update(validation);
                // Add Activity
                var newActivity = Activity.Create(createdBy, $"Cancelled a Prescription validation", doctorName);
                _dbContext.Activities.Add(newActivity);

                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cant Cancel a validation", ex);
                return;
            }
        }
    }
}