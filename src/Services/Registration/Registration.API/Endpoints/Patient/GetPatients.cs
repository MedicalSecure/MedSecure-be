using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Patients.Queries.GetPatients;

namespace Registration.Api.Endpoints.Patient
{
    public record GetPatientsResponse(PaginatedResult<PatientDto> Patients);

    public class GetPatients : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/patients", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetPatientsQuery(paginationRequest));

                var response = result.Adapt<GetPatientsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetPatients")
            .Produces<GetPatientsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Patients")
            .WithDescription("Get Patients");
        }
    }
}
