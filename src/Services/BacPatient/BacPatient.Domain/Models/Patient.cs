
namespace BacPatient.Domain.Models
{
    public class Patient : Aggregate<PatientId>
    {

        public string Name { get; private set; } = default!;
        public DateTime DateOfBirth { get; private set; } = default!;

        public string Gender { get; private set; } = default!;
        public int Age { get; private set; } = default!;
        public int Height { get; private set; } = default!;
        public int Weight { get; private set; } = default!;
        public string ActivityStatus { get; private set; } = default!;
        public List<string> Allergies { get; private set; } = default!;
        public string RiskFactor { get; private set; } = default!;
        public string FamilyHistory { get; private set; } = default!;

        public static Patient Create(
            PatientId Id,
            string Name,
            DateTime DateOfBirth,
            string Gender,
            int Age,
            int Height,
            int Weight,
            string ActivityStatus,
            List<string> Allergies,
            string RiskFactor,
            string FamilyHistory
        )
        {
            var patient = new Patient()
            {
                Id = Id,
                Name = Name,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                Age = Age,
                Height = Height,
                Weight = Weight,
                ActivityStatus = ActivityStatus,
                Allergies = Allergies,
                RiskFactor = RiskFactor,
                FamilyHistory = FamilyHistory
            };

            return patient;
        }


    }
}
