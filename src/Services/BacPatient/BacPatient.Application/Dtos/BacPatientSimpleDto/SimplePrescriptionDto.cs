using rescription.Application.DTOs;


namespace BacPatient.Application.Dtos.BacPatientSimpleDto
{
   
        public record SimplePrescriptionDto(
            Guid Id,
            SimpleRegisterDto Register,
            DateTime? CreatedAt ,
            ICollection<SimplePosologyDto> Posologies , 
            SimpleUnitCareDto UnitCare);
            public record GetPrescriptionsResult(PaginatedResult<PrescriptionDto> Prescriptions);
            public record SimplePosologyDto(Guid Id,
            Guid PrescriptionId,
            SimpleMedicationDto Medication,
            DateTime StartDate,
            DateTime? EndDate,
            bool IsPermanent,
            ICollection<SimpleCommentsDto> Comments,
            ICollection<SimpleDispensesDto> Dispenses);
            public record SimpleCommentsDto(Guid Id,
            Guid PosologyId,
            string Label,
            string Content);
             public record SimpleDispensesDto(
            Guid Id,
            Guid PosologyId,
            string Hour,
            Dose? BeforeMeal,
            Dose? AfterMeal)
    {
     
    };
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