using Registration.Domain.Enums;
using Registration.Domain.Models;

namespace Registration.Application.Dtos
{
    public record PatientDto(Guid Id, string firstName, string lastName, DateTime dateOfBirth, string identity, int cnam, string assurance, Gender gender, int height, int weight,Boolean addressIsRegisteraions, Boolean saveForNextTime,
            string email, string address1, string address2, Country country, string state,int zipCode, FamilyStatus familyStatus, Children children);
}
