using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Domain.Models;
using Registration.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.RiskFactors.Commands.CreateRiskFactor
{
    public class CreateRiskFactorHandler
    (IApplicationDbContext dbContext) : ICommandHandler<CreateRiskFactorCommand, CreateRiskFactorResult>
    {
        public async Task<CreateRiskFactorResult> Handle(CreateRiskFactorCommand command, CancellationToken cancellationToken)
        {
            // create Patient entity from command object
            // save to database
            // return result
            var riskFactor = CreateNewRiskFactor(command.RiskFactor);

            dbContext.RiskFactors.Add(riskFactor);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateRiskFactorResult(riskFactor.Id.Value);
        }

        private static RiskFactor CreateNewRiskFactor(RiskFactorDto riskFactorDto)
        {
            var newRiskFactor = RiskFactor.Create(
                id: RiskFactorId.Of(Guid.NewGuid()),
                key: riskFactorDto.key,
                value: riskFactorDto.value,
                subRiskFactor: riskFactorDto.subRiskFactor
                );

            return newRiskFactor;
        }
    }
}
