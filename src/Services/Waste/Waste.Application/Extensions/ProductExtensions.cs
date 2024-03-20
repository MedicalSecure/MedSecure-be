
namespace Waste.Application.Extensions;

public static partial class ProductExtensions
{
    public static IEnumerable<ProductDto> ToProductDto(this List<Product> products)
    {
        return products.Select(p => new ProductDto(
            Id: p.Id.Value,
            Name: p.Name,
            Weight: p.Weight));
    }
}