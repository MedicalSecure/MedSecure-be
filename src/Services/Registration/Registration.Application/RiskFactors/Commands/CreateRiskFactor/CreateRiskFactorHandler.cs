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

        public static RiskFactor CreateNewRiskFactor(RiskFactorDto riskFactorDto, RiskFactorId? parentId = null)
        {
            var newId = RiskFactorId.Of(Guid.NewGuid());
            var newRiskFactor = RiskFactor.Create(
                id: newId,
                key: riskFactorDto.Key,
                value: riskFactorDto.Value,
                code: riskFactorDto.Code,
                description: riskFactorDto.Description,
                isSelected: riskFactorDto.IsSelected,
                type: riskFactorDto.Type,
                icon: riskFactorDto.Icon,
                subRiskFactor: riskFactorDto.SubRiskFactor?.Select(child => CreateNewRiskFactor(child, newId)).ToList(),//recursive call with the newCreated id : newId will be the parentId for next childs
                riskFactorParentId: parentId
                );

            return newRiskFactor;
        }
    }
}