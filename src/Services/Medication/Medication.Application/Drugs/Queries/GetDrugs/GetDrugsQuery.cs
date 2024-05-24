namespace Medication.Application.Drugs.Queries.GetDrugs;


public record GetDrugsQuery(PaginationRequest PaginationRequest)
: IQuery<GetDrugsResult>;

public record GetDrugsResult(PaginatedResult<DrugDto> Drugs);
