using Prescription.Application.DTOs;
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
            return new RegisterDto(
                register.Id,
                register.PatientId,
                register.Patient.ToPatientDto(),
                register.FamilyMedicalHistory,
                register.PersonalMedicalHistory,
                register.Diseases,
                register.Allergies,
                register.History,
                register.Test,
                register.Prescriptions?.ToPrescriptionsDto(false).ToList()
            );
        }

        public static List<RegisterDto> ToRegisterDto(this IReadOnlyList<Register> registers)
        {
            return registers.Select(d => d.ToRegisterDto()).ToList();
        }
    }
}