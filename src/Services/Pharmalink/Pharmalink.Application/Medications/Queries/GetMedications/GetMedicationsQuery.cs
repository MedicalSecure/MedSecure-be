namespace Pharmalink.Application.Medications.Queries.GetMedications;

public record GetMedicationsQuery(PaginationRequest PaginationRequest)
: IQuery<GetMedicationsResult>;

public record GetMedicationsResult(PaginatedResult<MedicationDto> Medications);
