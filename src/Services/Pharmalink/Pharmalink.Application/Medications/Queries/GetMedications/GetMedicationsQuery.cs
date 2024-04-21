using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Pharmalink.Application.Dtos;

namespace Pharmalink.Application.Medications.Queries.GetMedications;

public record GetMedicationsQuery(PaginationRequest PaginationRequest)
: IQuery<GetMedicationsResult>;

public record GetMedicationsResult(PaginatedResult<MedicationDto> Medications);
