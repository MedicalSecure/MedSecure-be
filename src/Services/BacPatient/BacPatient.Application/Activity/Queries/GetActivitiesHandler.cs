using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.Activity.Queries
{
    public class GetActivitiesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetActivitiesQuery, GetActivitiesResult>
    {
        public async Task<GetActivitiesResult> Handle(GetActivitiesQuery query, CancellationToken cancellationToken)
        {
            // get Activities with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Activities.LongCountAsync(cancellationToken);

            var Activities = await dbContext.Activities
                           .OrderByDescending(o => o.CreatedAt)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            return new GetActivitiesResult(
                new PaginatedResult<ActivityDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    Activities.ToActivitiesDto()));
        }
    }
}
