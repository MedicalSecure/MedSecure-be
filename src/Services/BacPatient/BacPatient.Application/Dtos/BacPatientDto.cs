
namespace BacPatient.Application.Dtos;

public record BacPatientDto(
    Guid Id,
    RegisterDto Register , 
    UnitCareDto UnitCare , 
    int Bed
    ,Guid NurseId,
    int Served , 
    int ToServe ,
    StatusBP Status 
    );
