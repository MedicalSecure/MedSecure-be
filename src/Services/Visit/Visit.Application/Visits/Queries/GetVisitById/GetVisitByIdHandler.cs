

namespace Visit.Application.Visits.Queries.GetVisitById;

public class GetVisitByIdHandler(IApplicationDbContext dbContext) : IQueryHandler<GetVisitByIdQuery, GetVisitByIdResult>
{

    public async Task<GetVisitByIdResult> Handle(GetVisitByIdQuery query, CancellationToken cancellationToken)
    {
        //get visits by id Visit

        var visits = await dbContext.Visits
            .AsNoTracking()
             .Where(visit => visit.Id == VisitId.Of(query.id))
             .OrderBy(visit => visit.Id)
             .ToListAsync(cancellationToken);
        return new GetVisitByIdResult(visits.ToVisitDto());
    }
}
