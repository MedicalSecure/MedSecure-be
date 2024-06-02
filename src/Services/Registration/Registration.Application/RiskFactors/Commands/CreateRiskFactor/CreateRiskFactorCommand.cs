
namespace Registration.Application.RiskFactors.Commands.CreateRiskFactor
{
    public record CreateRiskFactorCommand(RiskFactorDto RiskFactor) : ICommand<CreateRiskFactorResult>;

    public record CreateRiskFactorResult(Guid Id);
    public class CreatePatientCommandValidator : AbstractValidator<CreateRiskFactorCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.RiskFactor).NotEmpty().WithMessage("RiskFactor  is required");
        }
    }
}
