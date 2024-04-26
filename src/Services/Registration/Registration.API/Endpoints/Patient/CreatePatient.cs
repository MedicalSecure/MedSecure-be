using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Patients.Commands.CreatePatient;

namespace Registration.Api.Endpoints.Patient
{
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
}
