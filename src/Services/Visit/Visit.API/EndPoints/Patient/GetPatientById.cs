namespace Visit.API.EndPoints.Patient;
//- Accepts a patient id as a parameter.
//- Constructs a GetPatientByIdQuery with the patient Id.
//- Retrieves the data and returns it.


public record GetPatientByIdRequest(Guid PatientId);
public record GetPatientByIdResponse(IEnumerable<PatientDto> Patients);

public class GetPatientById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/patients/{patientId}", async (Guid patientId, ISender sender) =>
        {
            var result = await sender.Send(new GetPatientByIdQuery(patientId));

            var response = result.Adapt<GetPatientByIdResponse>();

            if (response.Patients != null)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("Patient not found");
            }
        })
        .WithName("GetPatientById")
        .Produces<GetPatientByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Patient By Id")
        .WithDescription("Get Patient By Id");
    }
}



