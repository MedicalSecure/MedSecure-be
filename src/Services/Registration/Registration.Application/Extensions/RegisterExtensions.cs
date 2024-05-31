namespace Registration.Application.Extensions
{
    public static partial class RegisterExtensions
    {
        private static RegisterDto ToRegisterDto(Register register)
        {
            var x = new RegisterDto(
                Id: register.Id.Value,
                CreatedAt: register.CreatedAt,
                Patient: register.Patient.ToPatientDto(),
                FamilyMedicalHistory: register.FamilyMedicalHistory.ToRiskFactorDto().ToList(),
                PersonalMedicalHistory: register.PersonalMedicalHistory.ToRiskFactorDto().ToList(),
                Diseases: register.Disease.ToRiskFactorDto().ToList(),
                Allergies: register.Allergy.ToRiskFactorDto().ToList(),
                Test: register.Tests.ToTestDto().ToList(),
                History: register.History.ToList().ToHistoryDto().ToList(),
                Status: register.Status
            );
            return x;
        }

        public static IEnumerable<RegisterDto> ToRegisterDto(this List<Register> registers)
        {
            return registers.Select(r => ToRegisterDto(r)).ToList();
        }
    }
}