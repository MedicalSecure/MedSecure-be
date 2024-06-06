namespace Medication.Application.Validations.Queries;

public class GetValidationsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetValidationsQuery, GetValidationsResult>
{
    public async Task<GetValidationsResult> Handle(GetValidationsQuery query, CancellationToken cancellationToken)
    {
        // get Validations with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Validations.LongCountAsync(cancellationToken);

        var Posologies = await dbContext.Posologies
                        .Include(p => p.Comments)
                        .Include(p => p.Dispenses)
                        .Include(p => p.Drug)
                        //.Where(p=> p.Validation.Id == ValidationId.Of(x))
                        .ToListAsync();

        var validations = await dbContext.Validations.ToListAsync();

        return new GetValidationsResult(
            new PaginatedResult<ValidationDto>(
                pageIndex,
                pageSize,
                totalCount,
                validations.ToValidationsDto().ToList()
                ));
    }
}