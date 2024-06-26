﻿using Prescription.Application.Features.Diagnosis.Commands.CreateDiagnosis;

namespace Prescription.API.Endpoints.Diagnosis
{
    public record CreateDiagnosisRequest(DiagnosisDTO Diagnosis);
    public record CreateDiagnosisResponse(string Id);

    public class CreateDiagnosis : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/Prescription/Diagnosis", async (CreateDiagnosisRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateDiagnosisCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateDiagnosisResponse>();

                return Results.Created($"/Diagnosis/{response.Id}", response);
            })
            .WithName($"Create {nameof(Diagnosis)}")
            .Produces<CreateDiagnosisResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary($"Create {nameof(Diagnosis)}")
            .WithDescription($"Create {nameof(Diagnosis)}");
        }
    }
}