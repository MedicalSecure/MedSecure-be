using Registration.Application.Dtos;
using Registration.Domain.Models;


namespace Registration.Application.Extensions
{
    public static partial class RegisterExtensions
    {
        public static IEnumerable<RegisterDto> ToRegisterDto(this List<Domain.Models.Register> registers) 
        {
            return registers.Select(p =>new RegisterDto(
                Id : p.Id.Value,
                familyHistory:p.Familymedicalhistory,
                personalHistory:p.PersonalMedicalHistory));
        }
    }
}
