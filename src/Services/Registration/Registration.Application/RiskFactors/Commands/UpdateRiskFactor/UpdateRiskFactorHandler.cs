using BuildingBlocks.CQRS;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Application.Exceptions;
using Registration.Domain.Models;
using Registration.Domain.ValueObjects;


namespace Registration.Application.RiskFactors.Commands.UpdateRiskFactor
{
    public class UpdateRiskFactorHandler
    (IApplicationDbContext dbContext) : ICommandHandler<UpdateRiskFactorCommand, UpdateRiskFactorResult>
    {
        public async Task<UpdateRiskFactorResult> Handle(UpdateRiskFactorCommand command, CancellationToken cancellationToken)
        {
            // Update Patient entity from command object
            // save to database
            // return result
            var riskFactorId = RiskFactorId.Of(command.RiskFactor.Id);
            var riskFactor = await dbContext.RiskFactors.FindAsync([riskFactorId], cancellationToken);

            if (riskFactor == null)
            {
                throw new RiskFactorNotFoundException(command.RiskFactor.Id);
            }

            UpdatePatientWithNewValues(riskFactor, command.RiskFactor);

            dbContext.RiskFactors.Update(riskFactor);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateRiskFactorResult(true);
        }

        private static void UpdatePatientWithNewValues(RiskFactor riskFactor, RiskFactorDto riskFactorDto)
        {
            riskFactor.Update(riskFactorDto.key, riskFactorDto.value,riskFactorDto.code ,riskFactorDto.description,riskFactorDto.isSelected,riskFactorDto.type,riskFactorDto.icon, riskFactorDto.subRiskFactor);
        }

    }
}
