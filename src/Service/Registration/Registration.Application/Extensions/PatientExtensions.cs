using Registration.Application.Dtos;
using Registration.Domain.Models;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<PatientDto> ToPatientDto(this List<Patient> patients)
        {
            return patients.Select(p => new PatientDto(
                Id: p.Id.Value,
                patientName: p.PatientName,
                dateOfbirth: p.DateOfBirth.Date,
                gender: p.Gender,
                height: p.Height,
                weight: p.Weight,
                register:p.Register,
                riskFactor:p.RiskFactor,
                disease:p.Disease
                ));
        }
    }
}
