namespace Prescription.Application.Extensions
{
    public static class RegisterExtension
    {
        public static RegisterDto ToRegisterDto(this Register register)
        {
            return new RegisterDto(
                register.Id,
                register.Patient.ToPatientDto(),
                register.FamilyMedicalHistory.ToRiskFactorDto().ToList(),
                register.PersonalMedicalHistory.ToRiskFactorDto().ToList(),
                register.Diseases.ToRiskFactorDto().ToList(),
                register.Allergies.ToRiskFactorDto().ToList(),
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