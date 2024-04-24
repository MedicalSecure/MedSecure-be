

namespace Visit.Application.Visits.Queries.GetVisits;
public record GetVisitsQuery(PaginationRequest PaginationRequest) : IQuery<GetVisitsResult>;
public record GetVisitsResult(PaginatedResult<VisitDto> Visits);