
namespace BacPatient.Application.Dtos;

public record BacPatientDto(
    Guid Id,
    PrescriptionDto Prescription , 
    RoomDto Room , 
    int Bed
    ,Guid NurseId,
    int Served , 
    int ToServe ,
    StatusBP Status 
    );
