


namespace BacPatient.Domain.Models

{
    public class BacPatient : Aggregate<BacPatienId> 
    {
        public Prescription Prescription { get; set; } = default!;
        
        public Guid NurseId { get; private set; } = default!;
        public int Served { get; private set; } = default!;
        public int ToServe { get; private set; } = default!;
        public StatusBP Status { get; private set; }
   

        public static BacPatient Create(
            BacPatienId Id,
            Prescription Prescription,
            Guid NurseId,
            int Served,
            int ToServe,
            StatusBP Status
          
        )
        {
            var bacpatient = new BacPatient()
            {
                Id = Id,
                Prescription = Prescription,
                NurseId = NurseId,
               
                Served = Served,
                ToServe = ToServe,
                Status = Status,
             
            };

            bacpatient.AddDomainEvent(new BPCreatedEvent(bacpatient));

            return bacpatient;
        }
        public void Update(
    Prescription prescription,
    Guid nurseId,
    int served,
    int toServe,
    StatusBP status
)
        {
            Prescription = prescription;
            NurseId = nurseId;
            
            Served = served;
            ToServe = toServe;
            Status = status;
           

            AddDomainEvent(new BPUpdatedEvent(this));
        }
    }
}