
using BacPatient.Application.BacPatient.Queries.GetBacPatientById;

namespace BacPatient.API.Endpoints.BacPatient;

//- Accepts a Patient ID.
//- Uses a GetDietByPatientIdQuery to fetch diets.
//- Returns the list of diets for that Patient.

//public record GetDietByPatientIdRequest(Guid PatientId);
public record GetBacPatientByIdResponse(IEnumerable<BacPatientDto> BacPatients);

public class GetBacPatientById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/bacPatient/{Id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new GetBacPatientByIdQuery(Id));

            var response = result.Adapt<GetBacPatientByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBacPatientId")
        .Produces<GetBacPatientByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get bacPatient By Id")
        .WithDescription("Get bacPatient By Id");
    }
}