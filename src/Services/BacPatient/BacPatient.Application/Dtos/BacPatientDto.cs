
namespace BacPatient.Application.Dtos;

public record BacPatientDto(
    Guid Id,
    PrescriptionDto Prescription , 
    UnitCareDto UnitCare , 
    int Bed
    ,Guid NurseId,
    int Served , 
    int ToServe ,
    StatusBP Status 
    );
