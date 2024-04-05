namespace BacPatient.Application.BPModels.Queries.GetBPQuery
    ;

public record GetBacPatientQuery(PaginationRequest PaginationRequest)
: IQuery<GetBPResult>;

public record GetBPResult(PaginatedResult<BPModelDto> Diets);