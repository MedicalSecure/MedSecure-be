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
                Id: p.Id.Value,
               firstName: p.FirstName,
                lastName: p.LastName,
                dateOfbirth: p.DateOfBirth,
                cin: p.CIN,
                cnam: p.CNAM,
                gender: p.Gender,
                height: p.Height,
                weight: p.Weight,
                email: p.Email,
                address1: p.Address1,
                address2: p.Address2,
                country: p.Country,
                state: p.State,
                familyStatus: p.FamilyStatus,
                children: p.Children

                ));
        }
    }
}
