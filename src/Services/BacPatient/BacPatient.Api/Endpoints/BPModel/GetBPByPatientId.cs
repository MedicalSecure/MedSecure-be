﻿
namespace BacPatient.API.Endpoints.BPModel;

//- Accepts a Patient ID.
//- Uses a GetDietByPatientIdQuery to fetch diets.
//- Returns the list of diets for that Patient.

//public record GetDietByPatientIdRequest(Guid PatientId);
public record GetBacPatientByPatientIdResponse(IEnumerable<BPModelDto> bp);

public class GetBacPatientByPatientId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/bacPatient/patient/{patientId}", async (Guid patientId, ISender sender) =>
        {
            var result = await sender.Send(new GetBPByPatientIdQuery(patientId));

            var response = result.Adapt<GetBacPatientByPatientIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBacPatientByPatientId")
        .Produces<GetBacPatientByPatientIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get bacPatient By Patient")
        .WithDescription("Get bacPatient By Patient");
    }
}