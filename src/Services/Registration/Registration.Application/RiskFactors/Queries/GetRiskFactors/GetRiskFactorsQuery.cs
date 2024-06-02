using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Registration.Application.Dtos;


namespace Registration.Application.RiskFactors.Queries.GetRiskFactors
{
    public record GetRiskFactorsQuery(PaginationRequest PaginationRequest) : IQuery<GetRiskFactorsResult>;
    public record GetRiskFactorsResult(PaginatedResult<RiskFactorDto> RiskFactors);

}
