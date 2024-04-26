﻿
using Registration.Domain.Enums;
using Registration.Domain.Events;
using Registration.Domain.ValueObjects;

namespace Registration.Domain.Models
{
    public class Patient : Aggregate<PatientId>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public int CIN { get; set; } = default!;
        public int CNAM { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public int Height { get; set; } = default!;
        public int Weight { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address1 { get; set; } = default!;
        public string Address2 { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string State { get; set; } = default!;
        public FamilyStatus FamilyStatus { get; set; } = default!;
        public Children Children { get; set; } = default!;






        public static Patient Create(PatientId id, string firstName,string lastName, DateTime dateOfbirth,int cin,int cnam, Gender gender, int height, int weight,
            string email, string address1,string address2,string country,string state ,FamilyStatus familyStatus,Children children)
        {
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfbirth,
                CIN = cin,
                CNAM = cnam,
                Gender = gender,
                Height = height,
                Weight = weight,
                Email = email,
                Address1 = address1,
                Address2 = address2,
                Country = country,
                State = state,
                FamilyStatus = familyStatus,
                Children = children


            };
            patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }
        public void Update(string firstName, string lastName, DateTime dateOfbirth, int cin, int cnam, Gender gender, int height, int weight,
            string email, string address1, string address2, string country, string state, FamilyStatus familyStatus, Children children)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfbirth;
            CIN = cin;
            CNAM = cnam;
            Gender = gender;
            Height = height;
            Weight = weight;
            Email = email;
            Address1 = address1;
            Address2 = address2;
            Country = country;
            State = state;
            FamilyStatus = familyStatus;
            Children = children;
            

            AddDomainEvent(new PatientUpdatedEvent(this));
        }
    }
}
