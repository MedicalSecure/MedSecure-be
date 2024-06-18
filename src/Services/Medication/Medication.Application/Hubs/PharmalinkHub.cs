using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Medication.Application.Hubs.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Medication.Application.Hubs
{
    public class PharmaLinkHub(IHubContext<PharmaLinkHub> context) : Hub, IPharmaLinkHub
    {

        public async Task SendEventToAll(InpatientPrescriptionSharedEvent p)
        {
            await context.Clients.All.SendAsync("PrescriptionToValidateEvent", p);
        }
    }
}