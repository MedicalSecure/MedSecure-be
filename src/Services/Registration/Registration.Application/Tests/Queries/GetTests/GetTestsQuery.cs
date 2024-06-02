namespace Registration.Application.Tests.Queries.GetTests
{
    public record GetTestsQuery(PaginationRequest PaginationRequest) : IQuery<GetTestsResult>;
    public record GetTestsResult(PaginatedResult<TestDto> Tests);
}
