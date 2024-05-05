using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Histories.Commands.UpdateHistory;

namespace Registration.Api.Endpoints.History
{
    public record UpdateHistoryRequest(HistoryDto History);
    public record UpdateHistoryResponse(bool IsSuccess);
    public class UpdateHistory : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/histories", async (UpdateHistoryRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateHistoryCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateHistoryResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateHistory")
            .Produces<UpdateHistoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update History")
            .WithDescription("Update History");
        }
    }
}
