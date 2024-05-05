using System.Linq;

namespace Registration.Application.Tests.Queries.GetTests
{
    public class GetTestsHandler : IQueryHandler<GetTestsQuery, GetTestsResult>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetTestsHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetTestsResult> Handle(GetTestsQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await _dbContext.Tests.LongCountAsync(cancellationToken);

            var tests = await _dbContext.Tests
                .OrderBy(t => t.Description)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new GetTestsResult(
                  new PaginatedResult<TestDto>(
                      pageIndex,
                      pageSize,
                      totalCount,
                      tests.Select(t => new TestDto(
                          t.Id.Value,  // Provide the required 'Id' argument here
                          t.Code,
                          t.Description,
                          t.Language,
                          t.Type
                      )).ToList()
                  )
              );
        }
    }
}
