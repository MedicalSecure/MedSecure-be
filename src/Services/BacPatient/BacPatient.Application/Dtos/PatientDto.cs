
namespace BacPatient.Application.Dtos;

public record PatientDto(Guid Id,
            string Name,
            DateTime DateOfBirth,
            string Gender,
            int Age,
            int Height,
            int Weight,
            string ActivityStatus,
            List<string> Allergies,
            string RiskFactor,
            string FamilyHistory);