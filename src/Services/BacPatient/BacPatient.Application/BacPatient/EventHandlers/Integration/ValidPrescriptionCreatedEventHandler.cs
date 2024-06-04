using BuildingBlocks.Messaging.Events.PrescriptionEvents;

namespace BacPatient.Application.BacPatient.EventHandlers.Integration
{
    public class ValidPrescriptionCreatedEventHandler() : IConsumer<ValidatedPrescriptionSharedEvent>
    {
        public Task Consume(ConsumeContext<ValidatedPrescriptionSharedEvent> context)
        {
            var x = context.Message;
            Console.WriteLine(x);
            return Task.CompletedTask;
        }
    }
}