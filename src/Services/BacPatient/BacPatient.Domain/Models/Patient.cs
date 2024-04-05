
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

        public static Patient Create(
            PatientId id,
            string name,
            DateTime dateOfBirth,
            string gender,
            int age,
            int height,
            int weight,
            string activityStatus,
            List<string> allergies,
            string riskFactor,
            string familyHistory
        )
        {
            var patient = new Patient()
            {
                Id = id,
                name = name,
                dateOfBirth = dateOfBirth,
                gender = gender,
                age = age,
                height = height,
                weight = weight,
                activityStatus = activityStatus,
                Allergies = allergies,
                riskFactor = riskFactor,
                familyHistory = familyHistory
            };

            return patient;
        }


    }
}
