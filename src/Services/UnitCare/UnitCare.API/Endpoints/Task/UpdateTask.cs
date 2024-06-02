using UnitCare.Application.Tasks.Commands.UpdateTask;

namespace UnitCare.API.Endpoints.Task;


public record UpdateTaskRequest(TaskDto Task);
public record UpdateTaskResponse(bool IsSuccess);

public class UpdateTask : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/tasks", async (UpdateTaskRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateTaskCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateTaskResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateTask")
        .Produces<UpdateTaskResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Task")
        .WithDescription("Update Task");
    }
}