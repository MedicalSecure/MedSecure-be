using BuildingBlocks.Messaging.Events.Drugs;
using Microsoft.AspNetCore.SignalR;
using Prescription.Application.Hubs.Abstractions;

namespace Prescription.Application.Hubs
{
    public class PrescriptionHub(IHubContext<PrescriptionHub> context) : Hub, IPrescriptionHub
    {
        public async Task SendEventToAll(PrescriptionValidationSharedEvent p)
        {
            await context.Clients.All.SendAsync("PrescriptionRejected", p);
        }
    }
}