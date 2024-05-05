
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
        public string Assurance { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public int Height { get; set; } = default!;
        public int Weight { get; set; } = default!;
        //2 checkbox de type boolean
        public Boolean AddressIsRegisterations { get; set; } = default!;
        public Boolean SaveForNextTime { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address1 { get; set; } = default!;
        public string Address2 { get; set; } = default!;
        public ActivityStatus ActivityStatus { get; set; }
        public  Country Country { get; set; }
        public string State { get; set; } = default!;
        public int ZipCode { get; set; } = default!;
        public FamilyStatus FamilyStatus { get; set; } = default!;
        public Children Children { get; set; } = default!;






        public static Patient Create(PatientId Id,string firstName,string lastName, DateTime dateOfbirth,int cin,int cnam, string assurance, Gender gender, int height, int weight, Boolean addressIsRegisteraions, Boolean saveForNextTime,
            string email, string address1, string address2, Country country, string state, int zipCode, FamilyStatus familyStatus, Children children)
        {
            var patient = new Patient
            {
                Id= Id, 
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfbirth,
                CIN = cin,
                CNAM = cnam,
                Assurance = assurance,
                Gender = gender,
                Height = height,
                Weight = weight,
                AddressIsRegisterations = addressIsRegisteraions,
                SaveForNextTime = saveForNextTime,
                Email = email,
                Address1 = address1,
                Address2 = address2,
                Country = country,
                State = state,
                ZipCode = zipCode,
                FamilyStatus = familyStatus,
                Children = children


            };
            patient.AddDomainEvent(new PatientCreatedEvent(patient));

            return patient;
        }
        public void Update(string firstName, string lastName, DateTime dateOfbirth, int cin, int cnam, Gender gender, int height, int weight,
            string email, string address1, string address2, Country country, string state, FamilyStatus familyStatus, Children children)
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
