using Mapster;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis;

namespace Prescription.API.Endpoints.Diagnosis
{
    public record GetRegisterResponse(PaginatedResult<RegisterDto> Register);

    public class GetRegister : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/Prescription/Registration", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetRegisterQuery(paginationRequest));

                var response = result.Adapt<GetRegisterResponse>();

                return Results.Ok(response);
            })
            .WithName($"Get {nameof(Register)}")
            .Produces<GetRegisterResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary($"Get {nameof(Register)}")
            .WithDescription($"Get {nameof(Register)}");
        }
    }
}