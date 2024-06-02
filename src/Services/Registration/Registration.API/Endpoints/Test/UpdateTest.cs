using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Tests.Commands.UpdateTest;

namespace Registration.Api.Endpoints.Test
{
    public record UpdateTestRequest(TestDto Test);
    public record UpdateTestResponse(bool IsSuccess);
    public class UpdateTest : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/tests", async (UpdateTestRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateTestCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateTestResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateTest")
            .Produces<UpdateTestResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Test")
            .WithDescription("Update Test");
        }
    }
}
