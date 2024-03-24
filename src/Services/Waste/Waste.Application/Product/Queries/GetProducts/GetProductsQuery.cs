
namespace Waste.Application.Products.Queries.GetProducts;

public record GetProductsQuery(PaginationRequest PaginationRequest)
: IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Products);