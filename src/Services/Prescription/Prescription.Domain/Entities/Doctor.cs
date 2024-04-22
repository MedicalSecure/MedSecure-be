﻿namespace Prescription.Domain.Entities
{
    public class Doctor : Aggregate<Guid>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Speciality { get; init; }
        public DateTime DateOfBirth { get; init; }
        public ICollection<PrescriptionEntity> Prescriptions { get; set; }
        public Doctor()
        { } // For EF

        public static Doctor Create(string firstName, string lastName, string speciality, DateTime dateOfBirth)
        {
            return new Doctor { FirstName = firstName, LastName = lastName, Speciality = speciality, DateOfBirth = dateOfBirth };
        }

        public static Doctor Create(Guid id, string firstName, string lastName, string speciality, DateTime dateOfBirth)
        {
            return new Doctor { Id = id, FirstName = firstName, LastName = lastName, Speciality = speciality, DateOfBirth = dateOfBirth };
        }
    }
}