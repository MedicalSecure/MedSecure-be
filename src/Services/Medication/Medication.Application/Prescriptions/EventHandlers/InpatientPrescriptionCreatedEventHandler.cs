using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Medication.Application.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Medication.Application.Prescriptions.EventHandlers
{
    public class InpatientPrescriptionCreatedEventHandler : IConsumer<InpatientPrescriptionSharedEvent>
    {
        private readonly ISender _sender;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IApplicationDbContext _dbcontext;
        private readonly IHubContext<PharmalinkHub> _hubContext;

        public InpatientPrescriptionCreatedEventHandler(ISender sender, IPublishEndpoint publishEndpoint, IApplicationDbContext dbcontext, IHubContext<PharmalinkHub> hubContext)
        {
            _sender = sender;
            _publishEndpoint = publishEndpoint;
            _dbcontext = dbcontext;
            _hubContext = hubContext;
        }
        public async Task Consume(ConsumeContext<InpatientPrescriptionSharedEvent> context)
        {
            var p = context.Message;
            await _hubContext.Clients.All.SendAsync("PrescriptionToValidateEvent", p);

            var jsonUnitCare = JsonConvert.SerializeObject(p.UnitCare);
            var drugs = await _dbcontext.Drugs.ToListAsync();

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
        }
    }
}