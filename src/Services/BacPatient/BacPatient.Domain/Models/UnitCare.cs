
namespace BacPatient.Domain.Models
{
    public class UnitCare : Aggregate<UnitCareId>
    {
        public string title { get; private set; } = default!;
        public string type { get; private set; } = default!;

        public string description { get; private set; } = default!;
        public Status status { get; private set; } = default!;


    }
}
