namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record DiscontinuedInpatientPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid? ValidationId { get; set; }
        public Guid DoctorId { get; set; }
        public int Status { get; set; }
        public Guid BedId { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; } = new List<PosologySharedEvent>();
        public ICollection<SymptomSharedEvent> Symptoms { get; set; } = new List<SymptomSharedEvent>();
        public ICollection<DiagnosesSharedEvent> Diagnoses { get; set; } = new List<DiagnosesSharedEvent>();
        public DietForPrescriptionSharedEvent Diet { get; set; }
        public DateTime CreatedAt { get; set; }

        // Empty constructor
        public DiscontinuedInpatientPrescriptionSharedEvent() { }

        // Full constructor
        public DiscontinuedInpatientPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            Guid bedId,
            Guid? validationId,
            int status,
            ICollection<PosologySharedEvent> posologies,
            DietForPrescriptionSharedEvent diet,
            DateTime createdAt)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            BedId = bedId;
            Status = status;
            Posologies = posologies;
            Diet = diet;
            CreatedAt = createdAt;
            ValidationId = validationId;
        }
    }
}