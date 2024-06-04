using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Registration.Application.Histories.Commands.CreateHistory;

namespace Registration.Application.Histories.EventHandlers.Integration
{
    public class ValidPrescriptionCreatedEventHandler(ISender sender) : IConsumer<ValidatedPrescriptionSharedEvent>
    {
        public async Task Consume(ConsumeContext<ValidatedPrescriptionSharedEvent> context)
        {
            var pres = context.Message;
            var newResidentHistory = new HistoryDto(HistoryStatus.Resident, pres.RegisterId, null, DateTime.Now);//Id null to be created automatically
            var command = new CreateHistoryCommand(newResidentHistory);
            var response = await sender.Send(command);
            Console.WriteLine($"New history created : {response.Id}");
        }
    }
}