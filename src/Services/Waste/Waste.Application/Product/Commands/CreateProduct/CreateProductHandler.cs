
namespace Waste.Application.Products.Commands.CreateProduct;

public class CreateRoomHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // create Product entity from command object
        // save to database
        // return result
        var product = CreateNewProduct(command.Product);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id.Value);
    }

    private static Domain.Models.Product CreateNewProduct(ProductDto productDto)
    {
        var newProduct = Domain.Models.Product.Create(
         id: ProductId.Of(Guid.NewGuid()),
         name: productDto.Name,
         weight: productDto.Weight);

        return newProduct;
    }
}