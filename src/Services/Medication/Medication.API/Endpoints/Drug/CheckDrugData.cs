using Medication.Application.Drugs.Commands.CheckDrugData;

namespace Medication.API.Endpoints.Drug;

//- Accepts a CheckDrugDataRequest object.
//- Maps the request to a CheckDrugDataCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the checked drug list.

public record CheckDrugDataRequest(List<DrugDto> Drugs);
public record CheckDrugDataResponse(List<DrugDto> DrugsChecked);

public class CheckDrugData : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/drugsChecked", async (CheckDrugDataRequest request, ISender sender) =>
        {
            var command = request.Adapt<CheckDrugDataCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CheckDrugDataResponse>();

            return Results.Created($"/api/v1/drugsChecked/{response.DrugsChecked}", response);
        })
        .WithName("CheckDrugList")
        .Produces<CheckDrugDataResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Check Drug List")
        .WithDescription("Check Drug List");
    }
}
