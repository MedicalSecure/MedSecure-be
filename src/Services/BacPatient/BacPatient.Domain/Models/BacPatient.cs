


namespace BacPatient.Domain.Models
         
{
    public class BacPatient : Aggregate<Guid>
    {
        public Register Register { get; set; } = default!;
        public UnitCare UnitCare { get; private set; } = default!;
        public int Bed { get; private set; } = default!;
        public Guid NurseId { get; private set; } = default!;
        public int Served { get; private set; } = default!;
        public int ToServe { get; private set; } = default!;
        public StatusBP Status { get; private set; }
         

    public static BacPatient Create(
            Guid Id,
            Register Register,
            UnitCare UnitCare,
            Guid NurseId ,
            int Bed,
            int Served,
            int ToServe,
            StatusBP Status
        )
                {
            var bacpatient = new BacPatient()
            {
                Id = Id,
                Register = Register ,
                        UnitCare = UnitCare,
                        NurseId = NurseId , 
                        Bed = Bed,
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
    

    }
}
