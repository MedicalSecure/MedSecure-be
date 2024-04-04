
namespace BacPatient.Application.Dtos;

public record BPModelDto(Guid Id, Guid PatientId, Guid RoomId , Guid UnitCareId , int Bed , DateTime ServingDate , int Served , int ToServe , StatusBP Status , List<MedicineDto> Medicines);
