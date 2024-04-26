
namespace Registration.Application.Extensions
{
    public static partial class RegisterExtensions
    {
        public static IEnumerable<RegisterDto> ToRegisterDto(this List<Domain.Models.Register> registers) 
        {
            return registers.Select(p =>new RegisterDto(
                Id : p.Id.Value,
                patientId : p.PatientId.Value,
                patient:p.Patient,
                familyHistory:p.Familymedicalhistory,
                personalHistory:p.PersonalMedicalHistory,
                disease:p.Disease,
                allergy:p.Allergy
                ));
        }
    }
}
