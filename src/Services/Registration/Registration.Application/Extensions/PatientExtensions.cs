using Registration.Application.Dtos;
using Registration.Domain.Models;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<PatientDto> ToPatientDto(this List<Patient> patients)
        {
            return patients.Select(p => new PatientDto(
                id: p.Id.Value,
               firstName: p.FirstName,
                lastName: p.LastName,
                dateOfBirth: p.DateOfBirth,
                identity: p.Identity,
                cnam: p.CNAM,
                assurance:p.Assurance,
                gender: p.Gender,
                height: p.Height,
                weight: p.Weight,
                addressIsRegistrations: p.AddressIsRegisterations,
                saveForNextTime:p.SaveForNextTime,
                email: p.Email,
                address1: p.Address1,
                address2: p.Address2,
                country: p.Country,
                state: p.State,
                zipCode: p.ZipCode,
                familyStatus: p.FamilyStatus,
                children: p.Children


                ));
        }
    }
}
