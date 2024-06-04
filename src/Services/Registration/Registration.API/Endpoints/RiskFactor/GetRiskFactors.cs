using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.RiskFactors.Queries.GetRiskFactors;

namespace Registration.Api.Endpoints.RiskFactor
{
    public record GetRiskFactorsResponse(PaginatedResult<RiskFactorDto> RiskFactors);
    public class GetRiskFactors : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/riskFactors", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetRiskFactorsQuery(paginationRequest));

                var response = result.Adapt<GetRiskFactorsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetRiskFactors")
            .Produces<GetRiskFactorsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get RiskFactors")
            .WithDescription("Get RiskFactors");
        }
    }
}
