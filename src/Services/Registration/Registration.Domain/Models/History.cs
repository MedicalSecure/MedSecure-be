
namespace Registration.Domain.Models
{
    public class History:Aggregate<HistoryId>
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; } = Enums.Status.Resident;
        public PatientId PatientId { get; set; } = default!;
        //public Boolean IsResident { get; set; }
      
    }
}
