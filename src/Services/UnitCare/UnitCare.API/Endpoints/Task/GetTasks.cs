using UnitCare.API.Endpoints.UnitCare;
using UnitCare.Application.Tasks.Queries.GetTasks;

namespace UnitCare.API.Endpoints.Task;

public record GetTasksResponse(PaginatedResult<TaskDto> Tasks);

public class GetTasks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/tasks", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetTasksQuery(request));

            var response = result.Adapt<GetTasksResponse>();

            return Results.Ok(response);
        })
        .WithName("GetTasks")
        .Produces<GetTasksResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Task")
        .WithDescription("Get Task");
    }
}
