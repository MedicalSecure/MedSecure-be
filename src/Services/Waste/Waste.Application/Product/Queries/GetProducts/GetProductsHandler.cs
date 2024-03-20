
namespace Waste.Application.Products.Queries.GetProducts;

public class GetProductsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        // get Product with pagination
        // return result

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Products.LongCountAsync(cancellationToken);

        var products = await dbContext.Products
                       .OrderBy(o => o.Name)
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);
        return new GetProductsResult(
            new PaginatedResult<ProductDto>(
                pageIndex,
                pageSize,
                totalCount,
                products.ToProductDto()));
    }
}