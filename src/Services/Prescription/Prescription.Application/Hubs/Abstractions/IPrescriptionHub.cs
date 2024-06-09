using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.RegistrationEvents;

namespace Prescription.Application.Hubs.Abstractions
{
    public interface IPrescriptionHub
    {
        public Task SendPrescriptionValidationToAll(PrescriptionValidationSharedEvent p);
        public Task SendNewRegisterEventToAll(NewRegisterSharedEvent r);
    }
}