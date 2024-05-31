using Registration.Application.Dtos;
using Registration.Domain.Models;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static PatientDto ToPatientDto(this Patient p)
        {
            return new PatientDto(
                Id: p.Id.Value,
                FirstName: p.FirstName,
                LastName: p.LastName,
                DateOfBirth: p.DateOfBirth,
                Identity: p.Identity,
                CNAM: p.CNAM,
                Assurance: p.Assurance,
                Gender: p.Gender,
                Height: p.Height,
                Weight: p.Weight,
                AddressIsRegistrations: p.AddressIsRegisterations,
                SaveForNextTime: p.SaveForNextTime,
                Email: p.Email,
                Address1: p.Address1,
                Address2: p.Address2,
                Country: p.Country,
                State: p.State,
                ZipCode: p.ZipCode,
                FamilyStatus: p.FamilyStatus,
                Children: p.Children
            );
        }

        public static IEnumerable<PatientDto> ToPatientDto(this List<Patient> patients)
        {
            return patients.Select(p => p.ToPatientDto());
        }
    }
}