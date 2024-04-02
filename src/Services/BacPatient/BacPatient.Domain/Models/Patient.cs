
namespace BacPatient.Domain.Models
{
    public class Patient : Aggregate<PatientId>
    {

        public string name { get; private set; } = default!;
        public DateTime dateOfBirth { get; private set; } = default!;

        public string gender { get; private set; } = default!;
        public int age { get; private set; } = default!;
        public int height { get; private set; } = default!;
        public int weight { get; private set; } = default!;
        public string activityStatus { get; private set; } = default!;
        public List<string> Allergies { get; private set; } = default!;
        public string riskFactor { get; private set; } = default!;
        public string familyHistory { get; private set; } = default!;



    }
}
