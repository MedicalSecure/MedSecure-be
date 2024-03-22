
namespace Diet.API.Endpoints.Diet
{
    //- Accepts a Patient ID.
    //- Uses a GetDietByPatientIdQuery to fetch diets.
    //- Returns the list of diets for that Patient.

    //public record GetDietByPatientIdRequest(Guid PatientId);
    public record GetDietByPatientIdResponse(IEnumerable<DietDto> Orders);

    public class GetDietByPatientId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/diets/patient/{patientId}", async (Guid patientId, ISender sender) =>
            {
                var result = await sender.Send(new GetDietByPatientIdQuery(patientId));

                var response = result.Adapt<GetDietByPatientIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDietByPatientId")
            .Produces<GetDietByPatientIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Diets By Patient")
            .WithDescription("Get Diets By Patient");
        }
    }
}