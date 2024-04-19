using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.RiskFactors.Commands.CreateRiskFactor;

namespace Registration.Api.Endpoints.RiskFactor
{
    public record CreateRiskFactorRequest(RiskFactorDto RiskFactor);
    public record CreateRiskFactorResponse(string Id);

    public class CreateRiskFactor : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/riskFactors", async (CreateRiskFactorRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateRiskFactorCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateRiskFactorResponse>();

                return Results.Created($"/riskFactors/{response.Id}", response);
            })
            .WithName("CreateRiskFactor")
            .Produces<CreateRiskFactorResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create RiskFactor")
            .WithDescription("Create RiskFactor");
        }
    }
}
