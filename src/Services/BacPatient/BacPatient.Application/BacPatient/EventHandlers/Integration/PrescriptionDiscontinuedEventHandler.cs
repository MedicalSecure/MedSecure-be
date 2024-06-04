using BuildingBlocks.Messaging.Events.PrescriptionEvents;

namespace BacPatient.Application.BacPatient.EventHandlers.Integration
{
    public class PrescriptionDiscontinuedEventHandler(IApplicationDbContext dbcontext) : IConsumer<DiscontinuedInpatientPrescriptionSharedEvent>
    {
        public Task Consume(ConsumeContext<DiscontinuedInpatientPrescriptionSharedEvent> context)
        {
            var x = context.Message;
            Console.WriteLine(context.Message);
            return Task.Delay(5000);
        }
    }
}