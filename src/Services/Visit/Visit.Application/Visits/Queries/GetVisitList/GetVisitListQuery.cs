
namespace Visit.Application.Visits.Queries.GetVisitList;

public record GetVisitListQuery(PaginationRequest PaginationRequest) : IQuery<GetVisitListResult>;
public record GetVisitListResult(PaginatedResult<VisitDto> Visits);

