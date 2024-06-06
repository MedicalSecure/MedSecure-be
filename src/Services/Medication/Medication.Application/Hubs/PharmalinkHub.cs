using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Microsoft.AspNetCore.SignalR;

namespace Medication.Application.Hubs
{
    public class PharmalinkHub : Hub
    {
        public async Task SendEventToAll(InpatientPrescriptionSharedEvent p)
        {
            await Clients.All.SendAsync("PrescriptionToValidateEvent", p);
        }
    }
}
