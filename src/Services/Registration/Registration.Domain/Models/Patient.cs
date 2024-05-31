namespace Registration.Domain.Models;

public class Patient : Aggregate<PatientId>
{
    // Properties
    public string FirstName { get; private set; } = default!;

    public string LastName { get; private set; } = default!;
    public DateTime DateOfBirth { get; private set; } = default!;
    public string Identity { get; private set; } = default!;
    public int? CNAM { get; private set; } = default!;
    public string? Assurance { get; private set; } = default!;
    public Gender Gender { get; private set; } = default!;
    public int? Height { get; private set; } = default!;
    public int? Weight { get; private set; } = default!;
    public bool AddressIsRegisterations { get; private set; } = default!;
    public bool SaveForNextTime { get; private set; } = default!;
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
    private Patient()
    { }

    // Factory method
    public static Patient Create(
        PatientId id,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string identity,
        Gender gender,
        bool addressIsRegisterations,
        bool saveForNextTime,
        int? cnam = null,
        string? assurance = null,
        int? height = null,
        int? weight = null,
        string? email = null,
        string? address1 = null,
        string? address2 = null,
        Country? country = null,
        string? state = null,
        int? zipCode = null,
        FamilyStatus? familyStatus = null,
        Children? children = null)
    {
        // Validate parameters here

        var patient = new Patient
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Identity = identity,
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
    public bool Update(
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string identity,
        Gender gender,
        bool addressIsRegisterations,
        bool saveForNextTime,
        int? cnam = null,
        string? assurance = null,
        int? height = null,
        int? weight = null,
        string? email = null,
        string? address1 = null,
        string? address2 = null,
        Country? country = null,
        string? state = null,
        int? zipCode = null,
        FamilyStatus? familyStatus = null,
        Children? children = null)
    {
        // Validate parameters here if necessary

        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Identity = identity;
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
        AddressIsRegisterations = addressIsRegisterations;
        SaveForNextTime = saveForNextTime;
        Assurance = assurance;
        ZipCode = zipCode;

        AddDomainEvent(new PatientUpdatedEvent(this));
        return true;
    }
}