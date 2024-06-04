namespace UnitCare.Application.Tasks.Queries.GetTasks
{

    public class GetTasksHandler(IApplicationDbContext dbContext) : IQueryHandler<GetTasksQuery, GetTasksResult>
    {
        public async Task<GetTasksResult> Handle(GetTasksQuery query, CancellationToken cancellationToken)
        {
            // get Tasks with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Tasks.LongCountAsync(cancellationToken);

            var tasks = await dbContext.Tasks
                           .OrderByDescending(o => o.CreatedAt)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            return new GetTasksResult(
                new PaginatedResult<TaskDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                   tasks.ToTaskDto()));
        }
    }
}
