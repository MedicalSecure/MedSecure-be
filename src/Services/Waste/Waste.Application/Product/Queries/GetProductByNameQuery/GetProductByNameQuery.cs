
namespace Waste.Application.Products.Queries.GetProductyNameQuery
{
    public record GetProductyNameQuery(string Name) : IQuery<GetProductByNameResult>;

    public record GetProductByNameResult(IEnumerable<ProductDto> Products);
   
}
