
namespace Waste.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        // Update Product entity from command object
        // save to database
        // return result
        var productId = ProductId.Of(command.Product.Id);
        var product = await dbContext.Products.FindAsync([productId], cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException(command.Product.Id);
        }

        UpdateProductWithNewValues(product, command.Product);

        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
    private static void UpdateProductWithNewValues(Domain.Models.Product product, ProductDto productDto)
    {
        product.Update(productDto.Name, productDto.Weight);
    }
}