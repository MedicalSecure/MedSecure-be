using rescription.Application.DTOs;
using BacPatient.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Extensions
{
    public static class DoctorExtension
    {
        public static ICollection<DoctorDto> ToDoctorDto(this IReadOnlyList<Doctor> diagnoses)
        {
            return diagnoses.Select(d => d.ToDoctorDto()).ToList();
        }

        public static DoctorDto ToDoctorDto(this Doctor doctor)
        {
            return new DoctorDto(
            id: doctor.Id,
            firstName: doctor.FirstName,
            lastName: doctor.LastName,
            speciality: doctor.Speciality,
            dateOfBirth: doctor.DateOfBirth
        );
        }
    }
}