namespace Pharmalink.API.Endpoints.Medication;


//- Accepts a medication name, medication form or medication code as a parameter.
//- Constructs a GetMedicationByCreteriaQuery with the medication name, medication form or medication code.
//- Retrieves the data and returns it.



public record GetMedicationByCreteriaResopnse(IEnumerable <MedicationDto> Medications);

public class GetMedicationByCreteria : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/search", async ([AsParameters] Pharmalink.Application.Dtos.CreteriaDto creteria, ISender sender) =>
        {

            var result = await sender.Send(new GetMedicationByCreteriaQuery(creteria));

            var response = result.Adapt<GetMedicationByCreteriaResopnse>();

            if (response.Medications.Count() > 0)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("Medication not found");
            }
        })
        .WithName("search")
        .Produces<GetMedicationByCreteriaResopnse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Medication By Creteria")
        .WithDescription("Get Medication By Creteria");
    }
}