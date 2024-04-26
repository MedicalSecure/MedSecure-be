using Registration.Domain.Enums;
using Registration.Domain.Models;

namespace Registration.Application.Dtos
{
    public record PatientDto(Guid Id, string patientName, DateTime dateOfbirth, Gender gender, int height, int weight, Domain.Models.Register register, RiskFactor riskFactor, RiskFactor disease);
}
