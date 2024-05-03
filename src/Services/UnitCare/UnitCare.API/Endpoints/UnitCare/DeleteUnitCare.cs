using UnitCare.Application.UnitCares.Commands.DeleteUnitCare;

namespace UnitCare.API.Endpoints.UnitCare;


//- Accepts the Diet ID as a parameter.
//- Constructs a DeleteDietCommand.
//- Sends the command using MediatR.
//- Returns a success or not found response.

public record DeleteUnitCareRequest(Guid Id);
public record DeleteUnitCareResponse(bool IsSuccess);

public class DeleteUnitCare : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
   {
       app.MapDelete("/unitcares/{id}", async (Guid Id, ISender sender) =>
       {
           var result = await sender.Send(new DeleteUnitCareCommand(Id));

           var response = result.Adapt<DeleteUnitCareResponse>();

            return Results.Ok(response);
       })
      .WithName("DeleteUnitCare")
       .Produces<DeleteUnitCareResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
      .WithSummary("Delete UnitCare")
       .WithDescription("Delete UnitCare");
  }
}
