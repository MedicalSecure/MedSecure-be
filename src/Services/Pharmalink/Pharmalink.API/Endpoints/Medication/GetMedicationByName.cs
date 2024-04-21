using Mapster;
using MediatR;
using Pharmalink.Application.Dtos;
using Pharmalink.Application.Medications.Queries.GetMedicationByNameQuery;

namespace Pharmalink.API.Endpoints.Medication;

//- Accepts a medication name as a parameter.
//- Constructs a GetMedicationByNameQuery with the medication name.
//- Retrieves the data and returns it.

public record GetMedicationByNameRequest(string MedicationName);
public record GetMedicationByNameResponse(MedicationDto Medication);

public class GetMedicationByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/medications/{medicationName}", async (string medicationName, ISender sender) =>
        {
            var result = await sender.Send(new GetMedicationByNameQuery(medicationName));

            var response = result.Adapt<GetMedicationByNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetMedicationByName")
        .Produces<GetMedicationByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Medication By Name")
        .WithDescription("Get Medication By Name");
    }
}