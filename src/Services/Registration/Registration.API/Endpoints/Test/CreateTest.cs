using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Tests.Commands.CreateTest;

namespace Registration.Api.Endpoints.Test
{
    public record CreateTestRequest(TestDto Test);
    public record CreateTestResponse(string Id);
    public class CreateTest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/tests", async (CreateTestRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateTestCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateTestResponse>();

                return Results.Created($"/tests/{response.Id}", response);
            })
            .WithName("CreateTest")
            .Produces<CreateTestResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Test")
            .WithDescription("Create Test");
        }
    }
}
