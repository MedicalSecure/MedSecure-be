using BacPatient.Domain.Events.RegisterEvents;

namespace BacPatient.Domain.Models.RegisterRoot
{
    public class Patient : Aggregate<PatientId>
    {
        // Properties
        public string? FirstName { get; private set; } = default!;
        public string? LastName { get; private set; } = default!;
        public DateTime? DateOfBirth { get; private set; } = default!;
        public string? Identity { get; private set; } = default!;
        public int? CNAM { get; private set; } = default!;
        public string? Assurance { get; private set; } = default!;
        public Gender? Gender { get; private set; } = default!;
        public int? Height { get; private set; } = default!;
        public int? Weight { get; private set; } = default!;
        public bool? AddressIsRegisterations { get; private set; } = default!;
        public bool? SaveForNextTime { get; private set; } = default!;
        public string? Email { get; private set; } = default!;
        public string? Address1 { get; private set; } = default!;
        public string? Address2 { get; private set; } = default!;
        public ActivityStatus? ActivityStatus { get; private set; }
        public Country? Country { get; private set; }
        public string? State { get; private set; } = default!;
        public int? ZipCode { get; private set; } = default!;
        public FamilyStatus? FamilyStatus { get; private set; } = default!;
        public Children? Children { get; private set; } = default!;

        // Constructor (private to enforce creation through factory method)
        private Patient() { }

        // Factory method
        private Patient( PatientId patientid ,string firstName, string? lastName, DateTime? dateOfbirth)
        {
            Id = patientid;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfbirth;
        }
        public static Patient Create(string firstName, string? lastName, DateTime? dateOfbirth)
        {
            PatientId id = PatientId.Of(Guid.NewGuid());
            return new Patient( id ,firstName, lastName, dateOfbirth);
        }
        public static Patient Create(
            PatientId id,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string cin,
            int cnam,
            string assurance,
            Gender gender,
            int height,
            int weight,
            bool addressIsRegisterations,
            bool saveForNextTime,
            string email,
            string address1,
            string address2,
            Country country,
            string state,
            int zipCode,
            FamilyStatus familyStatus,
            Children children)
        {
            // Validate parameters here

            var patient = new Patient
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Identity = cin,
                CNAM = cnam,
                Assurance = assurance,
                Gender = gender,
                Height = height,
                Weight = weight,
                AddressIsRegisterations = addressIsRegisterations,
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

        // Method to update the patient
        public void Update(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string cin,
            int cnam,
            Gender gender,
            int height,
            int weight,
            string email,
            string address1,
            string address2,
            Country country,
            string state,
            FamilyStatus familyStatus,
            Children children)
        {
            // Validate parameters here if necessary

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Identity = cin;
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