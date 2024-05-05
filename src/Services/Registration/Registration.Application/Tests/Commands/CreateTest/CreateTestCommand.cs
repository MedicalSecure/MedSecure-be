namespace Registration.Application.Tests.Commands.CreateTest
{
    public record CreateTestCommand(TestDto Test) : IRequest<CreateTestResult>;
    public record CreateTestResult(Guid Id);

    public class CreateTestValidator : AbstractValidator<CreateTestCommand>
    {
        public CreateTestValidator()
        {
            RuleFor(x => x.Test.description).NotEmpty();
            RuleFor(x => x.Test.language).NotEmpty();
            RuleFor(x => x.Test.testType).NotEmpty();
            // Add additional validation rules as needed
        }
    }
}
