using BuildingBlocks.Messaging.Events.Drugs;

namespace Prescription.Application.Hubs.Abstractions
{
    public interface IPrescriptionHub
    {
        public Task SendEventToAll(PrescriptionValidationSharedEvent p);
    }
}