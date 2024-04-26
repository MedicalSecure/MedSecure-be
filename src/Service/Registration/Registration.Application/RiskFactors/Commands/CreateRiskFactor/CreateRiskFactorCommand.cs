using BuildingBlocks.CQRS;
using FluentValidation;
using Registration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
