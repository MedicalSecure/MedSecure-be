
namespace Registration.Application.Extensions
{
    public static partial class RegisterExtensions
    {
        public static IEnumerable<RegisterDto> ToRegisterDto(this List<Domain.Models.Register> registers) 
        {
            return registers.Select(p =>new RegisterDto(
                Id : p.Id.Value,
                patient:new PatientDto(
                    Id : p.Patient.Id.Value,
                firstName : p.Patient.FirstName,
                lastName : p.Patient.LastName,
                dateOfBirth : p.Patient.DateOfBirth,
                cin : p.Patient.CIN,
                cnam : p.Patient.CNAM,
                assurance :p.Patient.Assurance,
                gender: p.Patient.Gender,
                height : p.Patient.Height,
                weight : p.Patient.Weight,
                addressIsRegisteraions: p.Patient.AddressIsRegisterations,
                saveForNextTime: p.Patient.SaveForNextTime,
                email : p.Patient.Email,
                address1 : p.Patient.Address1,
                address2 : p.Patient.Address2,
                country : p.Patient.Country,
                state : p.Patient.State,
                zipCode: p.Patient.ZipCode,
                familyStatus : p.Patient.FamilyStatus,
                children : p.Patient.Children)
                ));
        }
    }
}
