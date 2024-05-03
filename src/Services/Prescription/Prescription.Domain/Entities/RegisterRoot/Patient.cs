namespace Prescription.Domain.Entities.RegisterRoot
{
    public class Patient : Aggregate<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } = default!;
        public int? CIN { get; set; } = default!;
        public int? CNAM { get; set; } = default!;
        public string? Assurance { get; set; } = default!;
        public Gender? Gender { get; set; } = default!;
        public int? Height { get; set; } = default!;
        public int? Weight { get; set; } = default!;

        //2 checkbox de type boolean
        public Boolean? AddressIsRegisterations { get; set; } = default!;

        public Boolean? SaveForNextTime { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? Address1 { get; set; } = default!;
        public string? Address2 { get; set; } = default!;
        public ActivityStatus? ActivityStatus { get; set; }
        public Country? Country { get; set; }
        public string? State { get; set; } = default!;
        public int? ZipCode { get; set; } = default!;
        public FamilyStatus? FamilyStatus { get; set; } = default!;
        public Children? Children { get; set; } = default!;

        public Register? Register { get; private set; } = default!;// don't add the registerID prop, one to one relationship,

        //Patient is the principal entity and Register is the dependent entity.
        // so the patient is created first, with null register, then we add its key as foreign key for the register
        //making the register dependent on the patient creation, and can't exist without it!
        public static Patient Create(string firstName, string lastName, DateTime dateOfbirth, int cin, int cnam, Gender gender, int height, int weight,
            string email, string address1, string address2, Country country, string state, FamilyStatus familyStatus, Children children)
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

        public static Patient Create(Guid id, string firstName, string lastName, DateTime dateOfbirth, int cin, int cnam, Gender gender, int height, int weight,
                                    string email, string address1, string address2, Country country, string state, FamilyStatus familyStatus, Children children)
        {
            var patient = new Patient
            {
                Id = id,
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