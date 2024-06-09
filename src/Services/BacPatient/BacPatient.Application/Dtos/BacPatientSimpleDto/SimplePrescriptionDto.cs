using rescription.Application.DTOs;

namespace BacPatient.Application.Dtos.BacPatientSimpleDto
{
    public record SimplePrescriptionDto(
      Guid Id,//Mapped
      SimpleRegisterDto Register,//WARNING
      DateTime? CreatedAt,//Mapped
      ICollection<SimplePosologyDto> Posologies,//Mapped
      SimpleUnitCareDto UnitCare);//Warning
    public record GetPrescriptionsResult(PaginatedResult<PrescriptionDto> Prescriptions);
    public record SimplePosologyDto(Guid Id,//Mapped
      Guid PrescriptionId,//Mapped
      SimpleMedicationDto Medication,//Mapped
      DateTime StartDate,//Mapped
      DateTime? EndDate,//Mapped
      bool IsPermanent,//Mapped
      ICollection<SimpleCommentsDto> Comments,//Mapped
      ICollection<SimpleDispensesDto> Dispenses);//Mapped
    public record SimpleCommentsDto(Guid Id,//Mapped
      Guid PosologyId,//Mapped
      string Label,//Mapped
      string Content);//Mapped
    public record SimpleDispensesDto(
      Guid Id,//Mapped
      Guid PosologyId,//Mapped
      string Hour,//Mapped
      Dose? BeforeMeal,//Mapped
      Dose? AfterMeal);//Mapped
    public record SimpleMedicationDto(
      Guid Id, //mapped
      string Name,//mapped
      string Dosage,//mapped
      Route? Form,//mapped
      string Description//mapped
    );
    public record SimpleEquipmentDto(
      Guid Id,//mapped
      string Reference//mapped
    );

    public record SimpleUnitCareDto(
      Guid Id,//mapped
      string Title,//mapped
      string Description,//mapped
      SimpleRoomDto Room // Warning
    );
    public record SimpleRoomDto(
      Guid Id,//mapped
      decimal? RoomNumber,//mapped
      Status? Status,//Warning  To check
      SimpleEquipmentDto Equipment // Mapped
    );
}