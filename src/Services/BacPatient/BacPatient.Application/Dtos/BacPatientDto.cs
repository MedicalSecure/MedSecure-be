
namespace BacPatient.Application.Dtos;

public record BacPatientDto(Guid Id,
    PatientDto Patient, 
    RoomDto Room , 
    UnitCareDto UnitCare ,
    int Bed,Guid NurseId,
    DateTime ServingDate,
    int Served , 
    int ToServe ,
    StatusBP Status , List<MedicineDto> Medicines);

