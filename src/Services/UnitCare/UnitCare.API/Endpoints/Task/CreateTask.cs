using UnitCare.Application.Tasks.Commands.CreateTask;

namespace UnitCare.API.Endpoints.Task
{
   
    public record CreateTaskRequest(TaskDto Task);
    public record CreateTaskCareResponse(Guid Id);

    public class CreateTask : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/tasks", async (CreateTaskRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateTaskCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateTaskCareResponse>();

                return Results.Created($"/tasks/{response.Id}", response);
            })
            .WithName("CreateTask")
            .Produces<CreateTaskCareResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Task")
            .WithDescription("Create Task");
        }
    }
}
 