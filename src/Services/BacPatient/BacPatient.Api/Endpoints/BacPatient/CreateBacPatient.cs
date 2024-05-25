

using BacPatient.Application.BPModels.Commands.CreateBacPatient;

namespace BacPatient.API.Endpoints.BPModel;


public record CreateBacPatientRequest(BacPatientDto BacPatients);
public record CreateBacPatientResponse(Guid Id);

public class CreateBacPatient : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/v1/bacPatient", async (CreateBacPatientRequest request, ISender sender) =>
        {
          //  var command = request.Adapt<CreateBacPatientCommand>();

           CreateBacPatientCommand command = new CreateBacPatientCommand(request.BacPatients);

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