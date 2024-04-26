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
            // get patients with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.RiskFactors.LongCountAsync(cancellationToken);

            var riskFactors = await dbContext.RiskFactors
                           .OrderBy(o => o.Key)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            return new GetRiskFactorsResult(
                new PaginatedResult<RiskFactorDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    riskFactors.ToRiskFactorDto()));
        }
    }
}

