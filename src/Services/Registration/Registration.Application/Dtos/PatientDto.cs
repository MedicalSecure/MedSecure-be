namespace Registration.Application.Dtos
{
    public record PatientDto(Guid? Id, string FirstName, string LastName, DateTime DateOfBirth, string Identity, Gender Gender, int? CNAM, string? Assurance,int? Height, int? Weight, bool? AddressIsRegistrations, bool? SaveForNextTime, string? Email, string? Address1, string? Address2, Country? Country, string? State, int? ZipCode, FamilyStatus? FamilyStatus, Children? Children);
}
