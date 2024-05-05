using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Histories.Commands.CreateHistory;

namespace Registration.Api.Endpoints.History
{
    public record CreateHistoryRequest(HistoryDto History);
    public record CreateHistoryResponse(string Id);
    public class CreateHistory : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/histories", async (CreateHistoryRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateHistoryCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateHistoryResponse>();

                return Results.Created($"/histories/{response.Id}", response);
            })
            .WithName("CreateHistory")
            .Produces<CreateHistoryResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create History")
            .WithDescription("Create History");
        }
    }
}
