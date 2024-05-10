﻿using BacPatient.Domain.Models.RegisterRoot;
using rescription.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions
{
    public static class RegisterExtension
    {
        public static RegisterDto ToRegisterDto(this Register register)
        {
            return new RegisterDto
            {
                Id = register.Id,
                PatientId = register.PatientId.Value,
                Patient = register.Patient.ToPatientDto(), // Assuming a ToDTO() extension method exists for the Patient entity
                FamilyMedicalHistory = register.FamilyMedicalHistory.ToRiskFactorsDto(), // Assuming a ToDTO() extension method exists for the RiskFactor entity
                PersonalMedicalHistory = register.PersonalMedicalHistory.ToRiskFactorsDto(),
                Diseases = register.Disease.ToRiskFactorsDto(),
                Allergies = register.Allergy.ToRiskFactorsDto(),
                History = register.History.ToHistoriesDto(), // Assuming a ToDTO() extension method exists for the History entity
                Test = register.Tests.ToTestsDto(), // Assuming a ToDTO() extension method exists for the Test entity
                Prescriptions = register.Prescriptions?.ToPrescriptionsDto().ToList() // Assuming a ToDTO() extension method exists for the Prescription entity
            };
        }

        public static ICollection<RegisterDto> ToRegisterDto(this IReadOnlyList<Register> patients)
        {
            return patients.Select(d => d.ToRegisterDto()).ToList();
        }
    }
}