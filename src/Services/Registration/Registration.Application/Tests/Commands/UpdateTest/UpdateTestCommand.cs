namespace Registration.Application.Tests.Commands.UpdateTest
{
    public record UpdateTestCommand(TestDto Test) : ICommand<UpdateTestResult>;
    public record UpdateTestResult(bool IsSuccess);

    public class UpdateTestCommandValidator : AbstractValidator<UpdateTestCommand>
    {
        public UpdateTestCommandValidator()
        {
            RuleFor(x => x.Test.Id).NotEmpty().WithMessage("TestId is required");
            RuleFor(x => x.Test.Code).NotEmpty().WithMessage("Code is required");
            RuleFor(x => x.Test.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Test.Language).NotEmpty().WithMessage("Language is required");
            RuleFor(x => x.Test.TestType).NotEmpty().WithMessage("Type is required");
        }
    }
}
