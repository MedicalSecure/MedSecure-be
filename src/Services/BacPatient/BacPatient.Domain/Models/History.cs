
namespace BacPatient.Domain.Models
{
    public class History : Aggregate<Guid>
    {
        public DateTime Date { get; set; }
        public Status Status { get; set; } = Enums.Status.unavailable;
        //public Boolean IsResident { get; set; }
      
    }
}
