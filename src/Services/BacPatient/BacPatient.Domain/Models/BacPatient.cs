﻿


namespace BacPatient.Domain.Models
         
{
    public class BacPatient : Aggregate<BacPatienId>
    {
        public Prescription Prescription { get; set; } = default!;
        public int Bed { get; private set; } = default!;
        public Guid NurseId { get; private set; } = default!;
        public int Served { get; private set; } = default!;
        public int ToServe { get; private set; } = default!;
        public StatusBP Status { get; private set; }
        public Room? Room { get; private set; } 

        public static BacPatient Create(
            BacPatienId Id,
            Prescription Prescription  ,
          
            Guid NurseId ,
            int Bed,
            int Served,
            int ToServe,
            StatusBP Status , 
            Room Room 
        )
                {
            var bacpatient = new BacPatient()
            {
                Id = Id,
                 Prescription = Prescription ,
                        NurseId = NurseId , 
                        Bed = Bed,
                        Served = Served,
                        ToServe = ToServe,
                        Status = Status , 
                        Room = Room
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