using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.RegistrationEvents;
using Microsoft.AspNetCore.SignalR;
using Prescription.Application.Hubs.Abstractions;

namespace Prescription.Application.Hubs
{
    public class PrescriptionHub(IHubContext<PrescriptionHub> context) : Hub, IPrescriptionHub
    {
        public async Task SendPrescriptionValidationToAll(PrescriptionValidationSharedEvent p)
        {
            await context.Clients.All.SendAsync("PrescriptionRejected", p);
        }

        public async Task SendNewRegisterEventToAll(NewRegisterSharedEvent p)
        {
            await context.Clients.All.SendAsync("NewRegister", p);
        }
        
    }
}