namespace Waste.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Weight { get; private set; } = default!;

    public static Product Create(ProductId id, string name, decimal weight)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weight);
        
        return new Product()
        {
            Id = id,
            Name = name,
            Weight = weight
        };
    }
}
