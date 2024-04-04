
namespace BacPatient.Domain.Models
{
    public class BPModel : Aggregate<BPModelId>
    {
        public PatientId PatientId { get; private set; } = default!;
        public RoomId RoomId { get; private set; } = default!;
        public UnitCareId UnitCareId { get; private set; } = default!;
        public int bed { get; private set; } = default!;
        public DateTime servingDate { get; private set; } = default!;
        public int served { get; private set; } = default!;
        public int toServe { get; private set; } = default!;
        public StatusBP status { get; private set; } = StatusBP.Pending;
        private readonly List<Medicine> _medicines = new();
        public IReadOnlyList<Medicine> Medicines => _medicines.AsReadOnly();

    public static BPModel Create(
            BPModelId id,
            PatientId patientId,
            RoomId roomId,
            UnitCareId unitCareId,
            int bed,
            DateTime servingDate,
            int served,
            int toServe,
            StatusBP status
        )
                {
                    var bp = new BPModel()
                    {
                        Id = id,
                        PatientId = patientId,
                        RoomId = roomId,
                        UnitCareId = unitCareId,
                        bed = bed,
                        servingDate = servingDate,
                        served = served,
                        toServe = toServe,
                        status = status
                    };

                    bp.AddDomainEvent(new BPCreatedEvent(bp));

                    return bp;
                }
        public void Update(
            PatientId patientId,
            RoomId roomId,
            UnitCareId unitCareId,
            int bed,
            DateTime servingDate,
            int served,
            int toServe,
            StatusBP status
            )
        {
            PatientId = patientId;
            RoomId = roomId;
            UnitCareId = unitCareId;
            this.bed = bed;
            this.servingDate = servingDate;
            this.served = served;
            this.toServe = toServe;
            this.status = status;

            AddDomainEvent(new BPUpdatedEvent(this));
        }
        public void AddMedicne(Medicine med)
        {
            if (med == null)
                throw new ArgumentNullException(nameof(med));

            _medicines.Add(med);
        }

    }
}
