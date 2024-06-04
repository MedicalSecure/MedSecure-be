using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Newtonsoft.Json;

namespace Medication.Application.Prescriptions.EventHandlers
{
    public class InpatientPrescriptionCreatedEventHandler(ISender sender, IPublishEndpoint publishEndpoint, IApplicationDbContext dbcontext) : IConsumer<InpatientPrescriptionSharedEvent>
    {
        public async Task Consume(ConsumeContext<InpatientPrescriptionSharedEvent> context)
        {
            var p = context.Message;
            var jsonUnitCare = JsonConvert.SerializeObject(p.UnitCare);
            //YOUR logic here

            //
            var isPrescriptionValid = true;
            var validatedPrescriptionEvent = new PrescriptionValidationSharedEvent(p.Id, p.RegisterId, Guid.NewGuid(), "Hammadi Phar", jsonUnitCare, isPrescriptionValid, "no remarques");
            await publishEndpoint.Publish(validatedPrescriptionEvent);
            //throw new NotImplementedException();
        }
    }
}