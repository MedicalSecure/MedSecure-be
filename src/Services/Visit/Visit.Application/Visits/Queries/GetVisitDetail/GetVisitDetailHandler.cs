
namespace Visit.Application.Visits.Queries.GetVisitDetail;

public class GetVisitDetailHandler (IApplicationDbContext dbContext) : IQueryHandler<GetVisitDetailQuery,GetVisitDetailResult>
{

    public  async Task<GetVisitDetailResult> Handle (GetVisitDetailQuery query,CancellationToken cancellationToken)
    {
        //get visits by id doctor

        var visits = await dbContext.Visits
            .AsNoTracking()
             .Where(visit => visit.DoctorId==DoctorId.Of(query.id))
             .OrderBy(visit => visit.Id)
             .ToListAsync(cancellationToken);
        return new GetVisitDetailResult(visits.ToVisitDto());
    }
}
