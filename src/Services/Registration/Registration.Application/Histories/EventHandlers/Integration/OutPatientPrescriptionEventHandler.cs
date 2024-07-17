using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Registration.Application.Histories.Commands.CreateHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.Histories.EventHandlers.Integration
{
    public class OutPatientPrescriptionEventHandler(ISender sender) : IConsumer<OutpatientPrescriptionSharedEvent>
    {
        public async Task Consume(ConsumeContext<OutpatientPrescriptionSharedEvent> context)
        {
            var pres = context.Message;
            var newResidentHistory = new HistoryDto(HistoryStatus.Out, pres.RegisterId, null, DateTime.Now);//Id null to be created automatically
            var command = new CreateHistoryCommand(newResidentHistory);
            var response = await sender.Send(command);
            Console.WriteLine($"New history created : {response.Id}");
        }
    }
}
