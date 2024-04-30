

namespace Visit.Application.Extensions;
public static partial class PatientExtensions
{
    public static IEnumerable<PatientDto> ToPatientDto(this List<Patient> patients)
    {
        return patients.Select(p => new PatientDto(
            Id: p.Id.Value,
            FirstName: p.FirstName,
            LastName: p.LastName,
            DateOfBirth: p.DateOfBirth,
            Gender: p.Gender));
    }
}
