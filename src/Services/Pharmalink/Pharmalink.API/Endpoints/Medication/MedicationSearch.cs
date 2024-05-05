namespace Pharmalink.API.Endpoints.Medication;


//- Accepts creteria : (medication name, medication form or medication code) as a parameter.
//- Constructs a MedicationSearchQuery with the medication name, medication form or medication code.
//- Retrieves the data and returns it.



public record MedicationSearchResopnse(IEnumerable <MedicationDto> Medications);

public class MedicationSearch : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/search", async ([AsParameters] CreteriaDto creteria, ISender sender) =>
        {

            var result = await sender.Send(new MedicationSearchQuery(creteria));

            var response = result.Adapt<MedicationSearchResopnse>();

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
        .Produces<MedicationSearchResopnse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Medication By Creteria")
        .WithDescription("Get Medication By Creteria");
    }
}