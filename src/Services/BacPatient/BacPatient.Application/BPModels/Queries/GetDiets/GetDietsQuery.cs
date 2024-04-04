namespace BacPatient.Application.BPModels.Queries.GetDiets;

public record GetDietsQuery(PaginationRequest PaginationRequest)
: IQuery<GetDietsResult>;

public record GetDietsResult(PaginatedResult<DietDto> Diets);