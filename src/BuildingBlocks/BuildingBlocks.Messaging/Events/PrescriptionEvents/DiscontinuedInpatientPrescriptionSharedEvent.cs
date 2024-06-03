namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record DiscontinuedInpatientPrescriptionSharedEvent(
        Guid Id,
        Guid RegisterId,
        Guid DoctorId,
        int Status,
        ICollection<PosologySharedEvent> Posologies,
        UnitCarePlanSharedEvent UnitCare,
        DietForPrescriptionSharedEvent Diet
        ) : IntegrationEvent;
}