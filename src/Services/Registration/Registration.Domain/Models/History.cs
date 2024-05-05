
using Registration.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registration.Domain.Models
{
    public class History:Aggregate<HistoryId>
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; } = Enums.Status.Resident;
        public PatientId AssociatedPatientId { get; set; } = default!;
        public virtual Patient Patient { get; set; } // Assuming Patient is the related entity
                                                     //public Boolean IsResident { get; set; }

        public static History Create(DateTime date,Status status,PatientId patientId)
    {
        var history = new History
        {

            Date = date,
            Status= status,
            AssociatedPatientId= patientId,
          
        };
        history.AddDomainEvent(new HistoryCreatedEvent(history));
        return history;
    }
    public void Update(DateTime date,Status status,PatientId patientId)
    {

        Date = date;
        Status = status;
        AssociatedPatientId = patientId;

        AddDomainEvent(new HistoryUpdatedEvent(this));
    }
  }
}


