
using BacPatient.Application.Dtos;

namespace BacPatient.API.Endpoints.BPModel;

//- Accepts a CreateDietRequest object.
//- Maps the request to a CreateDietCommand.
//- Uses MediatR to send the command to the corresponding handler.
//- Returns a response with the created diet's ID.

public record CreateBacPatientRequest(BPModelDto bp);
public record CreateBacPatientResponse(Guid Id);

public class CreateBacPatient : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/bacPatient", async (CreateBacPatientRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBPModelCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateBacPatientResponse>();

            return Results.Created($"/bacPatient/{response.Id}", response);
        })
        .WithName("CreateBacPatient")
        .Produces<CreateBacPatientResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create bacPatient")
        .WithDescription("Create bacPatient");
    }
}