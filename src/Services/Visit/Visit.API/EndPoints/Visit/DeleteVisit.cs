namespace Visit.API.EndPoints.Visit;
public record DeleteVisitRequest(Guid Id);
public record DeleteVisitResponse(bool Success);

public class DeleteVisit: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/visits/{visitId}", async (Guid Id, ISender sender) =>
        {
            var command = new DeleteVisitCommand(Id); 
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteVisitResponse>(); 
            return Results.Ok(response);
            
        })
        .WithName("DeleteVisit")
        .Produces<DeleteVisitResponse>(StatusCodes.Status204NoContent)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Delete Visit")
        .WithDescription("Delete Visit");
    }
}

