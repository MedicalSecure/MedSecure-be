using Mapster;
using MediatR;
using Pharmalink.Application.Dtos;
using Pharmalink.Application.Medications.Queries.GetMedicationByCodeQuery;

namespace Pharmalink.API.Endpoints.Medication;

//- Accepts a medication code as a parameter.
//- Constructs a GetMedicationByCodeQuery with the medication code.
//- Retrieves the data and returns it.

public record GetMedicationByCodeRequest(string MedicationCode);
public record GetMedicationByCodeResponse(MedicationDto Medication);

public class GetMedicationByCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/medications/{medicationCode}", async (string medicationCode, ISender sender) =>
        {
            var result = await sender.Send(new GetMedicationByCodeQuery(medicationCode));

            var response = result.Adapt<GetMedicationByCodeResponse>();

            return Results.Ok(response);
        })
        .WithName("GetMedicationByCode")
        .Produces<GetMedicationByCodeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Medication By Code")
        .WithDescription("Get Medication By Code");
    }
}
