using System;

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
        public StatusBP status { get; private set; } = default!;



    }
}
