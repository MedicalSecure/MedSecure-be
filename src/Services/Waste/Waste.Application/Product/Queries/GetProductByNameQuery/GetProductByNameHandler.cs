

namespace Waste.Application.Products.Queries.GetProductyNameQuery;

public class GetProductByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetProductyNameQuery, GetProductByNameResult>
{
    public async Task<GetProductByNameResult> Handle(GetProductyNameQuery query, CancellationToken cancellationToken)
    {
        // get products by Id using dbContext
        // return result
        var products = await dbContext.Products
             .AsNoTracking()
             .Where(o => o.Name.Contains(query.Name))
             .OrderBy(o => o.Id)
             .ToListAsync(cancellationToken);

        return new GetProductByNameResult(products.ToProductDto());
    }
}