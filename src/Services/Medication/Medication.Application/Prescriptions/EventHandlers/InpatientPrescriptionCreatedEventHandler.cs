using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Newtonsoft.Json;

namespace Medication.Application.Prescriptions.EventHandlers
{
    public class InpatientPrescriptionCreatedEventHandler(ISender sender, IPublishEndpoint publishEndpoint) : IConsumer<InpatientPrescriptionSharedEvent>
    {
        public async Task Consume(ConsumeContext<InpatientPrescriptionSharedEvent> context)
        {
            var p = context.Message;
            var jsonUnitCare = JsonConvert.SerializeObject(p.UnitCare);
            var validatedPrescriptionEvent = new PrescriptionValidationSharedEvent(p.Id, p.RegisterId, Guid.NewGuid(), "Hammadi Phar", jsonUnitCare, true, "no remarques");

            await publishEndpoint.Publish(validatedPrescriptionEvent);
            //throw new NotImplementedException();
        }
    }
}