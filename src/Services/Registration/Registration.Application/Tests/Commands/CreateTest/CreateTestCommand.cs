namespace Registration.Application.Tests.Commands.CreateTest
{
    public record CreateTestCommand(TestDto Test) : IRequest<CreateTestResult>;
    public record CreateTestResult(Guid Id);

    public class CreateTestValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestValidator()
        {
            RuleFor(x => x.Test.Description).NotEmpty();
            RuleFor(x => x.Test.Language).NotEmpty();
            RuleFor(x => x.Test.TestType).NotEmpty();
            // Add additional validation rules as needed
        }
    }
}
