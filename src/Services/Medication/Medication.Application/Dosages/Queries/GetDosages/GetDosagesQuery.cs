namespace Medication.Application.Dosages.Queries.GetDosages;


public record GetDosagesQuery(PaginationRequest PaginationRequest)
: IQuery<GetDosagesResult>;

public record GetDosagesResult(PaginatedResult<DosageDto> Dosages);