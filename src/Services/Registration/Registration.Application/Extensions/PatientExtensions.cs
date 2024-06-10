using Registration.Application.Dtos;
using Registration.Domain.Models;
using System.Linq;

namespace Registration.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static PatientDto ToPatientDto(this Patient p, bool archived = false)
        {
            return new PatientDto(
                Id: p.Id.Value,
                FirstName: archived ? "*Archived*" : p.FirstName,
                LastName: archived ? "*Archived*" : p.LastName,
                DateOfBirth: archived ? new DateTime() : p.DateOfBirth,
                Identity: archived ? "*Archived*" : p.Identity,
                CNAM: archived ? null : p.CNAM,
                Assurance: archived ? "*Archived*" : p.Assurance,
                Gender: p.Gender,
                Height: archived ? null : p.Height,
                Weight: archived ? null : p.Weight,
                AddressIsRegistrations: p.AddressIsRegisterations,
                SaveForNextTime: p.SaveForNextTime,
                Email: archived ? "*Archived*" : p.Email,
                Address1: archived ? "*Archived*" : p.Address1,
                Address2: archived ? "*Archived*" : p.Address2,
                Country: archived ? null : p.Country,
                State: archived ? "*Archived*" : p.State,
                ZipCode: archived ? null : p.ZipCode,
                ActivityStatus: archived ? null : p.ActivityStatus,
                FamilyStatus: archived ? null : p.FamilyStatus,
                Children: archived ? null : p.Children
            );
        }

        public static IEnumerable<PatientDto> ToPatientDto(this List<Patient> patients, bool archived = false)
        {
            return patients.Select(p => p.ToPatientDto(archived));
        }
    }
}