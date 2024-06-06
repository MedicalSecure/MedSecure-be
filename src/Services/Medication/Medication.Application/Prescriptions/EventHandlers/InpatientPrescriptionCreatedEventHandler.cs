using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Medication.Application.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Medication.Application.Prescriptions.EventHandlers
{
    public class InpatientPrescriptionCreatedEventHandler : IConsumer<InpatientPrescriptionSharedEvent>
    {
        private readonly ISender _sender;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHubContext<PharmalinkHub> _hubContext;

        public InpatientPrescriptionCreatedEventHandler(ISender sender, IPublishEndpoint publishEndpoint, IApplicationDbContext dbcontext, IHubContext<PharmalinkHub> hubContext)
        {
            _sender = sender;
            _publishEndpoint = publishEndpoint;
            _dbContext = dbcontext;
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<InpatientPrescriptionSharedEvent> context)
        {
            var p = context.Message;

            //TODO REMOVE AFTER TESTS
            await _hubContext.Clients.All.SendAsync("PrescriptionToValidateEvent", p);

            //continue preparing the event
            var jsonUnitCare = JsonConvert.SerializeObject(p.UnitCare);
            var drugs = await _dbContext.Drugs.ToListAsync();

            foreach (var posology in p.Posologies)
            {
                var drug = drugs.FirstOrDefault(d => d.Id == DrugId.Of(posology.Medication.Id));
                if (drug != null)
                {
                    var isPrescriptionValid = false;
                    var availableStock = drug.AvailableStock;
                    int quantityNeeded = 0;

                    foreach (var dispense in posology.Dispenses)
                    {
                        var dispenseBeforeMeal = dispense.BeforeMeal?.Quantity ?? 0;
                        var dispenseAfterMeal = dispense.AfterMeal?.Quantity ?? 0;

                        quantityNeeded += dispenseBeforeMeal + dispenseAfterMeal;
                    }

                    if (quantityNeeded < availableStock)
                    {
                        // Enough stock available
                        isPrescriptionValid = true;
                        //await _hubContext.Clients.All.SendAsync("PrescriptionToValidateEvent", p);
                    }
                    else
                    {
                        // Not enough stock available
                        isPrescriptionValid = false;
                        var validatedPrescriptionEvent = new PrescriptionValidationSharedEvent(p.Id, p.RegisterId, Guid.NewGuid(), "Hammadi Phar", jsonUnitCare, isPrescriptionValid, "Quantity Not Sufficient");
                        await _publishEndpoint.Publish(validatedPrescriptionEvent);
                    }
                }
            }

            var newValidation = CreateValidationFromEvent(p);
            try
            {
                _dbContext.Validations.Add(newValidation);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);// if the event occurred twice for the same prescription => just log it and return ..
                return;
            }
        }

        private Validation CreateValidationFromEvent(InpatientPrescriptionSharedEvent ev)
        {
            var jsonUnitCare = JsonConvert.SerializeObject(ev.UnitCare);
            var validation = Validation.Create(ev.Id, jsonUnitCare);
            var drugs = _dbContext.Drugs.ToList();
            foreach (var posology in ev.Posologies)
            {
                //TODO REMOVE THE COMMENT
                //var drug = drugs.FirstOrDefault(d => d.Id == DrugId.Of(posology.MedicationId));
                var drug = drugs.FirstOrDefault();
                if (drug == null)
                    throw new NotFoundException($"Drug with id {posology.MedicationId} not found");
                var newPosology = Posology.Create(validation.Id, drug.Id);

                foreach (var comment in posology.Comments)
                {
                    var newComment = Comment.Create(newPosology.Id, comment.Label, comment.Content, "Hammadi Phar", DateTime.UtcNow);
                    if (newComment != null)
                        newPosology.AddComment(newComment);
                }

                foreach (var dispense in posology.Dispenses)
                {
                    var disp = Dispense.Create(newPosology.Id, dispense.Hour, dispense.BeforeMeal?.Quantity, dispense.AfterMeal?.Quantity, "Hammadi Phar", DateTime.UtcNow);
                    if (disp != null)
                        newPosology.AddDispense(disp);
                }

                validation.addPosology(newPosology);
            }

            return validation;
        }
    }
}