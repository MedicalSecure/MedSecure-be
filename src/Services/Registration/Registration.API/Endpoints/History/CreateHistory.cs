using Carter;
using Mapster;
using MediatR;
using Registration.Api.Endpoints.Register;
using Registration.Application.Dtos;
using Registration.Application.Histories.Commands.CreateHistory;
using Registration.Application.Registers.Commands.ArchiveUnarchiveRegister;

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
                if (request != null && request.History.RegisterId != Guid.Empty)
                {
                    try
                    {
                        var command = request.Adapt<CreateHistoryCommand>();

                        var result = await sender.Send(command);

                        var response = result.Adapt<CreateHistoryResponse>();
                        return Results.Created($"/histories/{response.Id}", response);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message, ex.InnerException?.ToString() ?? ex.Message, 500);
                    }
                }
                else
                {
                    return Results.BadRequest("Request object or RegisterId is null.");
                }
            })
            .WithName("CreateHistory")
            .Produces<CreateHistoryResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create History")
            .WithDescription("Create History");
        }
    }
}