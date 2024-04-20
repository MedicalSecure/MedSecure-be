using Prescription.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Extensions
{
    public static class PatientExtension
    {
        public static PatientDto ToPatientDto(this Patient p)
        {
            return new PatientDto(
                id: p.Id,
                patientName: p.PatientName,
                dateOfBirth: p.DateOfBirth.Date,
                gender: p.Gender,
                height: p.Height,
                weight: p.Weight,
                register: p.Register,
                riskFactor: p.RiskFactor,
                disease: p.Disease
                );
        }

        public static ICollection<PatientDto> ToPatientDto(this IReadOnlyList<Patient> patients)
        {
            return patients.Select(d => d.ToPatientDto()).ToList();
        }
    }
}