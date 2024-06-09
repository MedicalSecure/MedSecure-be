using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Extensions;
using Prescription.Application.Features.Activity.Queries.GetActivities;

namespace Prescription.Application.Features.Activities.Queries.GetActivities
{
    public class GetActivitiesHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext) : IQueryHandler<GetActivitiesQuery, GetActivitiesResult>
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