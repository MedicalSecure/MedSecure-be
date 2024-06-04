namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record InpatientPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid DoctorId { get; set; }
        public int Status { get; set; }
        public ICollection<SymptomSharedEvent> Symptoms { get; set; }
        public ICollection<DiagnosesSharedEvent> Diagnoses { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; }
        public UnitCarePlanSharedEvent UnitCare { get; set; }
        public DietForPrescriptionSharedEvent Diet { get; set; }
        public DateTime CreatedAt { get; set; }

        // Empty constructor
        public InpatientPrescriptionSharedEvent() { }

        // Full constructor
        public InpatientPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            int status,
            ICollection<SymptomSharedEvent> symptoms,
            ICollection<DiagnosesSharedEvent> diagnoses,
            ICollection<PosologySharedEvent> posologies,
            UnitCarePlanSharedEvent unitCare,
            DietForPrescriptionSharedEvent diet,
            DateTime createdAt)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            Status = status;
            Symptoms = symptoms;
            Diagnoses = diagnoses;
            Posologies = posologies;
            UnitCare = unitCare;
            Diet = diet;
            CreatedAt = createdAt;
        }
    }
}