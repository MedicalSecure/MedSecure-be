﻿using rescription.Application.DTOs;


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
                    Guid Id,
                    string Name,
                    string Dosage,
                    Route? Form,
                    string Description
                                        );
    public record SimpleUnitCareDto (
           Guid Id,
            string Title,
            string Description
        );
    public record SimpleRoomDto (
        Guid Id , 
            decimal? RoomNumber ,
     Status? Status 
        );
}

