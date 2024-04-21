using Mapster;
using MediatR;
using Pharmalink.Application.Dtos;
using Pharmalink.Application.Medications.Queries.GetMedicationByFormQuery;

namespace Pharmalink.API.Endpoints.Medication;

//- Accepts a medication form as a parameter.
//- Constructs a GetMedicationByFormQuery with the medication form.
//- Retrieves the data and returns it.

public record GetMedicationByFormRequest(string MedicationForm);
public record GetMedicationByFormResponse(MedicationDto Medication);

public class GetMedicationByForm : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/medications/{medicationForm}", async (string medicationForm, ISender sender) =>
        {
            var result = await sender.Send(new GetMedicationByFormQuery(medicationForm));

            var response = result.Adapt<GetMedicationByFormResponse>();

            return Results.Ok(response);
        })
        .WithName("GetMedicationByName")
        .Produces<GetMedicationByFormResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Medication By Form")
        .WithDescription("Get Medication By Form");
    }
}
