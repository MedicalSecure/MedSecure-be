
namespace Diet.API.Endpoints.Patient
{
    //- Accepts a patient name as a parameter.
    //- Constructs a GetPatientByNameQuery with the patient name.
    //- Retrieves the data and returns it.

    public record GetPatientByNameRequest(string PatientName);
    public record GetPatientByNameResponse(IEnumerable<PatientDto> Patients);

    public class GetPatientByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/patients/{patientName}", async (string patientName, ISender sender) =>
            {
                var result = await sender.Send(new GetPatientByNameQuery(patientName));

                var response = result.Adapt<GetPatientByNameResponse>();

                if (response.Patients != null)
                {
                    return Results.Ok(response);
                }
                else
                {
                    return Results.NotFound("Patient not found");
                }
            })
            .WithName("GetPatientByName")
            .Produces<GetPatientByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Patient By Name")
            .WithDescription("Get Patient By Name");
        }
    }
}