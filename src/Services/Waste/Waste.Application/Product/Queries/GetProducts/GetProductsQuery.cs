
public record GetProductsQuery(PaginationRequest PaginationRequest)
: IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Products);