using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Application.Extensions;


namespace Registration.Application.RiskFactors.Queries.GetRiskFactors
{
    public class GetRiskFactorsHandler(IApplicationDbContext dbContext) : IQueryHandler<GetRiskFactorsQuery, GetRiskFactorsResult>
    {
        public async Task<GetRiskFactorsResult> Handle(GetRiskFactorsQuery query, CancellationToken cancellationToken)

        {

            bool removeDuplicatedRiskFactors = true;
            // get patients with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.RiskFactors.LongCountAsync(cancellationToken);

            var riskFactors = removeDuplicatedRiskFactors ? 
                    await dbContext.RiskFactors
                           .OrderByDescending(o => o.CreatedAt)
                           .ToListAsync(cancellationToken) :
                    await dbContext.RiskFactors
                        .OrderByDescending(o => o.CreatedAt)
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync(cancellationToken);


            IEnumerable<RiskFactorDto> dtos = [];
            if (removeDuplicatedRiskFactors)
                dtos = riskFactors
                .Where(r => r.RiskFactorParentId == null) // don't include the children in the parent list(hey are duplicated in two levels), they will be included inside the parents
                .ToRiskFactorDto();
            else
                dtos = riskFactors
                .ToRiskFactorDto();
                
            return new GetRiskFactorsResult(
                new PaginatedResult<RiskFactorDto>(
                    removeDuplicatedRiskFactors ? 0 : pageIndex,
                    removeDuplicatedRiskFactors ? dtos.Count() : pageSize,
                    totalCount,
                    dtos));
        }
    }
}

