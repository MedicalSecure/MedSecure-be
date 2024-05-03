using Prescription.Domain.Entities.RegisterRoot;
using rescription.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Extensions
{
    public static class RegisterExtension
    {
        public static RegisterDto ToRegisterDto(this Register register)
        {
            return new RegisterDto
            {
                Id = register.Id,
                PatientId = register.PatientId,
                Patient = register.Patient.ToPatientDto(), // Assuming a ToDTO() extension method exists for the Patient entity
                FamilyMedicalHistory = register.FamilyMedicalHistory, // Assuming a ToDTO() extension method exists for the RiskFactor entity
                PersonalMedicalHistory = register.PersonalMedicalHistory,
                Diseases = register.Diseases,
                Allergies = register.Allergies,
                History = register.History, // Assuming a ToDTO() extension method exists for the History entity
                Test = register.Test, // Assuming a ToDTO() extension method exists for the Test entity
                Prescriptions = register.Prescriptions?.ToPrescriptionsDto().ToList() // Assuming a ToDTO() extension method exists for the PrescriptionEntity entity
            };
        }

        public static ICollection<RegisterDto> ToRegisterDto(this IReadOnlyList<Register> patients)
        {
            return patients.Select(d => d.ToRegisterDto()).ToList();
        }
    }
}