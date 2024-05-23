namespace Registration.Application.Extensions
{
    public static partial class RegisterExtensions
    {
        private static RegisterDto ToRegisterDto(Register register)
        {
            var x = new RegisterDto(
                id: register.Id,
                createdAt: register.CreatedAt,
                patient: register.Patient.ToPatientDto(),
                familyMedicalHistory: register.FamilyMedicalHistory.ToRiskFactorDto().ToList(),
                personalMedicalHistory: register.PersonalMedicalHistory.ToRiskFactorDto().ToList(),
                diseases: register.Disease.ToRiskFactorDto().ToList(),
                allergies: register.Allergy.ToRiskFactorDto().ToList(),
                test: register.Tests.ToTestDto().ToList(),
                history: register.History.ToList().ToHistoryDto().ToList(),
                status: register.Status
                );
            return x;
        }

        public static IEnumerable<RegisterDto> ToRegisterDto(this List<Register> registers)
        {
            return registers.Select(r => ToRegisterDto(r)).ToList();
        }
    }
}