namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record InpatientPrescriptionSharedEvent(
        Guid Id,
        Guid RegisterId,
        Guid DoctorId,
        int Status,
        ICollection<SymptomSharedEvent> Symptoms,
        ICollection<DiagnosesSharedEvent> Diagnoses,
        ICollection<PosologySharedEvent> Posologies,
        UnitCarePlanSharedEvent UnitCare,
        DietForPrescriptionSharedEvent Diet
        ) : IntegrationEvent;
}