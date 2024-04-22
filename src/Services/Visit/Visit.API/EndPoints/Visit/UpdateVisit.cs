namespace Visit.API.EndPoints.Visit;


public record UpdateVisitRequest (VisitDto Visit);
public record UpdateVisitResponse (bool IsSuccess);
public class UpdateVisit :ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/v1/visits", async (UpdateVisitRequest request, ISender sender) =>
       {
           var command = request.Adapt<UpdateVisitCommand>();
           var result = await sender.Send(command);
           var response = result.Adapt<UpdateVisitResponse>();
           return Results.Ok(response);
       })

         .WithName("UpdateVisit")
        .Produces<UpdateVisitResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Visit")
        .WithDescription("Update Visit");
    }
}
