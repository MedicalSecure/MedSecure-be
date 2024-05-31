namespace Registration.Application.Extensions
{
    public static partial class RegisterExtensions
    {
        public static RegisterDto ToRegisterDto(this Register register, bool isArchived = false)
        {
            var x = new RegisterDto(
                Id: register.Id.Value,
                CreatedAt: register.CreatedAt,
                Patient: register.Patient.ToPatientDto(isArchived),
                FamilyMedicalHistory: isArchived ? [] : register.FamilyMedicalHistory.ToRiskFactorDto().ToList(),
                PersonalMedicalHistory: isArchived ? [] : register.PersonalMedicalHistory.ToRiskFactorDto().ToList(),
                Diseases: isArchived ? [] : register.Disease.ToRiskFactorDto().ToList(),
                Allergies: isArchived ? [] : register.Allergy.ToRiskFactorDto().ToList(),
                Test: isArchived ? [] : register.Tests.ToTestDto().ToList(),
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