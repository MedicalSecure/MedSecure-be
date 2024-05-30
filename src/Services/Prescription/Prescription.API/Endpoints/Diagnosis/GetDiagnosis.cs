using Mapster;
using Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis;

namespace Prescription.API.Endpoints.Diagnosis
{
    public record GetDiagnosisResponse(PaginatedResult<DiagnosisDTO> diagnosis);

    public class GetDiagnosis : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/Prescription/Diagnosis", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetDiagnosisQuery(paginationRequest));

                var response = result.Adapt<GetDiagnosisResponse>();

                return Results.Ok(response);
            })
            .WithName($"Get {nameof(Diagnosis)}")
            .Produces<GetDiagnosisResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary($"Get {nameof(Diagnosis)}")
            .WithDescription($"Get {nameof(Diagnosis)}");
        }
    }
}