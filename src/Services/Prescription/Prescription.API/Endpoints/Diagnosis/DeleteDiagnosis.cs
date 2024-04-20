using Mapster;
using Microsoft.AspNetCore.Mvc;
using Prescription.Application.Features.Diagnosis.Commands.CreateDiagnosis;
using Prescription.Application.Features.Diagnosis.Commands.DeleteDiagnosis;
using Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis;

namespace Prescription.API.Endpoints.Diagnosis
{
    public record DeleteDiagnosisRequest(DiagnosisDto Diagnosis);
    public record DeleteDiagnosisResponse(Guid Id);

    public class DeleteDiagnosis : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/diagnosis", async ([FromBody] DeleteDiagnosisRequest request, ISender sender) =>
            {
                var command = request.Adapt<DeleteDiagnosisCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<DeleteDiagnosisResponse>();

                return Results.Ok(response);
            })
            .WithName($"Delete {nameof(Diagnosis)}")
            .Produces<GetDiagnosisResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary($"Delete {nameof(Diagnosis)}")
            .WithDescription($"Delete {nameof(Diagnosis)}");
        }
    }
}