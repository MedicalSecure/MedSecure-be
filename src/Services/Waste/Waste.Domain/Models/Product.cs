namespace Waste.Domain.Models;

public class Product : Aggregate<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Weight { get; private set; } = default!;

    public static Product Create(ProductId id, string name, decimal weight)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(weight);
        
        var product = new Product()
        {
            Id = id,
            Name = name,
            Weight = weight
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    public void Update(string name, decimal weight)
    {
        Name = name;
        Weight = weight;

        AddDomainEvent(new ProductUpdatedEvent(this));
    }
}