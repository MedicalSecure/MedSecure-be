using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Registration.Application.Histories.Commands.CreateHistory;

namespace Registration.Application.Histories.EventHandlers.Integration
{
    public class OutPatientPrescriptionEventHandler : IConsumer<OutpatientPrescriptionSharedEvent>
    {
        private readonly ISender _sender;
        private readonly IApplicationDbContext _dbContext;

        public OutPatientPrescriptionEventHandler(ISender sender, IApplicationDbContext dbContext)
        {
            _sender = sender;
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OutpatientPrescriptionSharedEvent> context)
        {
            var pres = context.Message;

            var register = await _dbContext.Registers
             .Include(r => r.History)
             .FirstOrDefaultAsync(r => r.Id == RegisterId.Of(new Guid(pres.RegisterId.ToByteArray())));

            if (register == null)
            {
                Console.WriteLine("Register not found.");
                return;
            }

            var latestHistory = register.History
            .Where(h => h.RegisterId == register.Id)
            .OrderByDescending(h => h.Date)
            .FirstOrDefault();

            if (latestHistory == null || latestHistory.Status != HistoryStatus.Registered)
            {
                Console.WriteLine("The status is not changeable.");
                return;
            }

            else
            {
                var newResidentHistory = new HistoryDto(HistoryStatus.Out, pres.RegisterId, null, DateTime.Now);
                var command = new CreateHistoryCommand(newResidentHistory);
                var response = await _sender.Send(command);
                Console.WriteLine($"New history created: {response.Id}");
            }

        }
    }
}
