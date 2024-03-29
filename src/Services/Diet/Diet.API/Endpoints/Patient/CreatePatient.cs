﻿
namespace Diet.API.Endpoints.Patient;

//- Accepts a CreatePatientRequest object.
//- Maps the request to a CreatePatientCommand.
//- Uses MediatR to send the command for processing.
//- Returns a response with the created patient's ID.

public record CreatePatientRequest(PatientDto Patient);
public record CreatePatientResponse(string Id);

public class CreatePatient : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/patients", async (CreatePatientRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreatePatientCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreatePatientResponse>();

            return Results.Created($"/patients/{response.Id}", response);
        })
        .WithName("CreatePatient")
        .Produces<CreatePatientResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Patient")
        .WithDescription("Create Patient");
    }
}