
namespace BacPatient.Application.Dtos
{
    public record PatientDto(
        Guid Id, string firstName, string lastName, DateTime dateOfbirth, int cin, int cnam, Gender gender, int height, int weight,
            string email, string address1, string address2, Country country, string state, FamilyStatus familyStatus, Children children);
}
