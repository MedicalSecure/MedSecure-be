
namespace Waste.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(ProductDto Product) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Product.Id).NotEmpty().WithMessage("Product.Id is required");
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Product.Name is required");
        RuleFor(x => x.Product.Weight).GreaterThan(0).WithMessage("Product.Weight is should not be empty");
    }
}
