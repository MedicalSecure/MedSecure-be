using Mapster;
using Prescription.Application.Features.Diagnosis.Commands.UpdateDiagnosis;

namespace Prescription.API.Endpoints.Diagnosis
{

    public record UpdateDiagnosisRequest(DiagnosisDto Diagnosis);
    public record UpdateDiagnosisResponse(Guid Id);

    public class UpdateDiagnosis : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/api/diagnosis", async (UpdateDiagnosisRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateDiagnosisCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateDiagnosisResponse>();

                return Results.Ok( response);
            })
            .WithName($"Update {nameof(Diagnosis)}")
            .Produces<UpdateDiagnosisResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary($"Update {nameof(Diagnosis)}")
            .WithDescription($"Update {nameof(Diagnosis)}");
        }
    }
}
