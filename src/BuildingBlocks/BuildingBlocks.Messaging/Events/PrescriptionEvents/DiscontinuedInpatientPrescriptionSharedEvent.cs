namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record DiscontinuedInpatientPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid DoctorId { get; set; }
        public int Status { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; }
        public UnitCarePlanSharedEvent UnitCare { get; set; }
        public DietForPrescriptionSharedEvent Diet { get; set; }

        // Empty constructor
        public DiscontinuedInpatientPrescriptionSharedEvent() { }

        // Full constructor
        public DiscontinuedInpatientPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            int status,
            ICollection<PosologySharedEvent> posologies,
            UnitCarePlanSharedEvent unitCare,
            DietForPrescriptionSharedEvent diet)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            Status = status;
            Posologies = posologies;
            UnitCare = unitCare;
            Diet = diet;
        }
    }
}