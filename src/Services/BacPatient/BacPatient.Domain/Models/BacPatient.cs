
namespace BacPatient.Domain.Models
{
    public class BacPatient : Aggregate<BacPatienId>
    {
        public Patient Patient { get; private set; } = default!;
        public Room Room { get; private set; } = default!;
        public UnitCare UnitCare { get; private set; } = default!;
        public int Bed { get; private set; } = default!;
        public Guid NurseId { get; private set; } = default!;
        public DateTime ServingDate { get; private set; } = default!;
        public int Served { get; private set; } = default!;
        public int ToServe { get; private set; } = default!;
       /* private readonly List<Meals> _meals= new();
        public IReadOnlyList<Meals> Meals => _medicines.AsReadOnly();*/
        public StatusBP Status { get; private set; } = StatusBP.Pending;
        private readonly List<Medication> _medicines = new();
        public IReadOnlyList<Medication> Medicines => _medicines.AsReadOnly();

    public static BacPatient Create(
            BacPatienId Id,
            Patient Patient,
            Room Room,
            UnitCare UnitCare,
            Guid NurseId ,
            int Bed,
            DateTime ServingDate,
            int Served,
            int ToServe,
            StatusBP Status
        )
                {
                    var bacpatient = new BacPatient()
                    {
                        Id = Id,
                        Patient = Patient,
                        Room = Room,
                        UnitCare = UnitCare,
                        NurseId = NurseId , 
                        Bed = Bed,
                        ServingDate = ServingDate,
                        Served = Served,
                        ToServe = ToServe,
                        Status = Status
                    };

            bacpatient.AddDomainEvent(new BPCreatedEvent(bacpatient));

                    return bacpatient;
                }
        public void Update(
            StatusBP Status
            )
        {
            this.Status = Status;

            AddDomainEvent(new BPUpdatedEvent(this));
        }
        public void AddMedicne(Medication med)
        {
            if (med == null)
                throw new ArgumentNullException(nameof(med));

            _medicines.Add(med);
        }

    }
}
