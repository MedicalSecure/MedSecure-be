using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.RiskFactors.Commands.UpdateRiskFactor;

namespace Registration.Api.Endpoints.RiskFactor
{
    public record UpdateRiskFactorRequest(RiskFactorDto RiskFactor);

    public record UpdateRiskFactorResponse(bool IsSuccess);

    public class UpdateRiskFactor : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut(
                    "/riskFactors",
                    async (UpdateRiskFactorRequest request, ISender sender) =>
                    {
                        var command = request.Adapt<UpdateRiskFactorCommand>();

                        var result = await sender.Send(command);

                        var response = result.Adapt<UpdateRiskFactorResponse>();

                        return Results.Ok(response);
                    }
                )
                .WithName("UpdateRiskFactor")
                .Produces<UpdateRiskFactorResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Update RiskFactor")
                .WithDescription("Update RiskFactor");
        }
    }
}
