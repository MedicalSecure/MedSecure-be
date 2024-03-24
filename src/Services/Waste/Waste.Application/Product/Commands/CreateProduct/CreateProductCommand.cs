
namespace Waste.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(ProductDto Product) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is should not be empty");
        RuleFor(x => x.Product.Weight).GreaterThan(0).WithMessage("Weight is should be > 0");
    }
}

