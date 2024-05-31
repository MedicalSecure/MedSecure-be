namespace Medication.API.Endpoints.Drug;


//- Accepts creteria : (drug name, drug form or drug code) as a parameter.
//- Constructs a SearchDrugQuery with the drug name, drug form or drug code.
//- Retrieves the data and returns it.


public record SearchDrugResponse(IEnumerable<DrugDto> Drugs);
public class SearchDrug : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/search", async ([AsParameters] CreteriaDto creteria, ISender sender) =>
        {

            var result = await sender.Send(new SearchDrugQuery(creteria));

            var response = result.Adapt<SearchDrugResponse>();

            if (response.Drugs.Count() > 0)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("Drug not found");
            }
        })
        .WithName("search")
        .Produces<SearchDrugResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Drug By Creteria")
        .WithDescription("Get Drug By Creteria");
    }
}
