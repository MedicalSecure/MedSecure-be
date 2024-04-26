using BuildingBlocks.CQRS;
using FluentValidation;
using Registration.Application.Dtos;



namespace Registration.Application.RiskFactors.Commands.UpdateRiskFactor
{
    public record UpdateRiskFactorCommand(RiskFactorDto RiskFactor) : ICommand<UpdateRiskFactorResult>;

    public record UpdateRiskFactorResult(bool IsSuccess);

    public class UpdateRiskFactorCommandValidator : AbstractValidator<UpdateRiskFactorCommand>
    {
        public UpdateRiskFactorCommandValidator()
        {
            RuleFor(x => x.RiskFactor.Id).NotEmpty().WithMessage("PatientId is required");
        }
    }
}
