namespace BacPatient.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<PatientDto> ToPatientDtos(this IEnumerable<Patient> Patients)
        {
            return Patients.Select(d => new PatientDto(
                            Id: d.Id.Value,
                            Name:d.Name,
                            DateOfBirth:d.DateOfBirth,
                            Gender:d.Gender,
                            Age:d.Age,
                            Height:d.Height,
                            Weight:d.Weight,
                            ActivityStatus:d.ActivityStatus,
                            Allergies:d.Allergies,
                            RiskFactor:d.RiskFactor,
                            FamilyHistory:d.FamilyHistory

));
        }
    }
}
