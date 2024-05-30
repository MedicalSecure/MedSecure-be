namespace Registration.Application.Dtos
{
    public record PatientDto
    {
        public Guid? Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string Identity { get; init; }
        public int? CNAM { get; init; }
        public string? Assurance { get; init; }
        public Gender? Gender { get; init; }
        public int? Height { get; init; }
        public int? Weight { get; init; }
        public bool? AddressIsRegistrations { get; init; }
        public bool? SaveForNextTime { get; init; }
        public string? Email { get; init; }
        public string? Address1 { get; init; }
        public string? Address2 { get; init; }
        public Country? Country { get; init; }
        public string? State { get; init; }
        public int? ZipCode { get; init; }
        public FamilyStatus? FamilyStatus { get; init; }
        public Children? Children { get; init; }

        public PatientDto(
            Guid id,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string identity,
            int? cnam,
            string? assurance,
            Gender? gender,
            int? height,
            int? weight,
            bool? addressIsRegistrations,
            bool? saveForNextTime,
            string? email,
            string? address1,
            string? address2,
            Country? country,
            string? state,
            int? zipCode,
            FamilyStatus? familyStatus,
            Children? children)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Identity = identity;
            this.CNAM = cnam;
            this.Assurance = assurance;
            this.Gender = gender;
            this.Height = height;
            this.Weight = weight;
            this.AddressIsRegistrations = addressIsRegistrations;
            this.SaveForNextTime = saveForNextTime;
            this.Email = email;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Country = country;
            this.State = state;
            this.ZipCode = zipCode;
            this.FamilyStatus = familyStatus;
            this.Children = children;
        }
    }
}
