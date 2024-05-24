namespace Medication.API.Endpoints.Drug;


//- Accepts a CreateDrugRequest object.
//- Maps the request to a CreateDrugCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the created drug's ID.

public record CreateDrugRequest(List<DrugDto> Drugs);
public record CreateDrugResponse(List<Guid> IDs);

public class CreateDrug : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/drugs", async (CreateDrugRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateDrugCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateDrugResponse>();

            return Results.Created($"/api/v1/drugs/{response.IDs}", response);
        })
        .WithName("CreateDrugList")
        .Produces<CreateDrugResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Drug List")
        .WithDescription("Create Drug List");
    }
}
