
namespace Visit.Application.Visits.Queries.GetVisitDetail;

public record GetVisitDetailQuery(Guid id) :IQuery<GetVisitDetailResult>;
public record GetVisitDetailResult(IEnumerable<VisitDto>Visits);