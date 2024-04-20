using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Domain.DTOs
{
    public record DoctorDto
    {
        public DoctorDto()
        {
        }
        public DoctorDto(Guid id, string firstName, string lastName, string speciality, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Specialty = speciality;
        }
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Specialty { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}