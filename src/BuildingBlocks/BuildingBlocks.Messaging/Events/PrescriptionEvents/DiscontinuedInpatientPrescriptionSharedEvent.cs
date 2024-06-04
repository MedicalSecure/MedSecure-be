namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record DiscontinuedInpatientPrescriptionSharedEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public Guid RegisterId { get; set; }
        public Guid DoctorId { get; set; }
        public int Status { get; set; }
        public Guid BedId { get; set; }
        public ICollection<PosologySharedEvent> Posologies { get; set; }
        public DietForPrescriptionSharedEvent Diet { get; set; }

        // Empty constructor
        public DiscontinuedInpatientPrescriptionSharedEvent() { }

        // Full constructor
        public DiscontinuedInpatientPrescriptionSharedEvent(
            Guid id,
            Guid registerId,
            Guid doctorId,
            Guid bedId,
            int status,
            ICollection<PosologySharedEvent> posologies,
            DietForPrescriptionSharedEvent diet)
        {
            Id = id;
            RegisterId = registerId;
            DoctorId = doctorId;
            BedId = bedId;
            Status = status;
            Posologies = posologies;
            Diet = diet;
        }
    }
}