using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions
{

    public static partial class PatientExtensions
    {
        public static PatientDto ToPatientDto(this Patient d)
        {
            return new PatientDto(
                Id: d.Id,
                firstName: d.FirstName,
                lastName: d.LastName,
                dateOfbirth: d.DateOfBirth,
                cin: d.CIN,
                cnam: d.CNAM,
                gender: d.Gender,
                height: d.Height,
                weight: d.Weight,
                email: d.Email,
                address1: d.Address1,
                address2: d.Address2,
                country: d.Country,
                state: d.State,
                familyStatus: d.FamilyStatus,
                children: d.Children);
        }

        public static ICollection<PatientDto> ToPatientDto(this IReadOnlyList<Patient> patients)
        {
            return patients.Select(d => d.ToPatientDto()).ToList();
        }
    }
}

