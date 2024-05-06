using rescription.Application.DTOs;


namespace BacPatient.Application.Dtos.BacPatientSimpleDto
{
   
        public record SimplePrescriptionDto(
   Guid Id,
   SimpleRegisterDto Register
  );
        public record GetPrescriptionsResult(PaginatedResult<PrescriptionDto> Prescriptions);

        public record SimplePosologyDto(Guid Id,
            Guid PrescriptionId,
            SimpleMedicationDto Medication,
            DateTime StartDate,
            DateTime? EndDate,
            bool IsPermanent,
            ICollection<CommentsDto> Comments,
            ICollection<DispensesDto> Dispenses);

        public record SimpleCommentsDto(Guid Id,
            Guid PosologyId,
            string Label,
            string Content);

        public record SimpleDispensesDto(Guid Id,
            Guid PosologyId,
            int Hour,
            int? QuantityBE,
            int? QuantityAE);
    public record SimpleMedicationDto(Guid Id,
    string Name,
    string Dosage,
    string Form,
    string Description);
}

