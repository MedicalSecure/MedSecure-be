namespace Visit.API.EndPoints.Visit;
public record DeleteVisitRequest(Guid Id);
public record DeleteVisitResponse(bool IsSuccess);

public class DeleteVisit: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/v1/visits/{visitId}", async (Guid Id, ISender sender) =>
        {
            var command = new DeleteVisitCommand(Id); 
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteVisitResponse>(); 
            return Results.Ok(response);
            
        })
        .WithName("DeleteVisit")
        .Produces<DeleteVisitResponse>(StatusCodes.Status200OK)
         .ProducesProblem(StatusCodes.Status400BadRequest)
         .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Visit")
        .WithDescription("Delete Visit");
    }
}

