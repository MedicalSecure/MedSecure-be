using Medication.Application.Validations.Queries;

namespace Medication.API.Endpoints.Validations;

public record GetValidationsResponse(PaginatedResult<ValidationDto> Validations);

public class GetValidations : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/Validations", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetValidationsQuery(paginationRequest));

            var response = result.Adapt<GetValidationsResponse>();

            return Results.Ok(response);
        })
        .WithName($"Get {nameof(Validations)}")
        .Produces<GetValidationsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary($"Get {nameof(Validations)}")
        .WithDescription($"Get {nameof(Validations)}");

        app.MapGet("/api/v1/PendingValidations", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new GetValidationsQuery(paginationRequest, true));

            var response = result.Adapt<GetValidationsResponse>();

            return Results.Ok(response);
        })
        .WithName($"Get Pending{nameof(Validations)}")
        .Produces<GetValidationsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary($"Get Pending{nameof(Validations)}")
        .WithDescription($"Get Pending{nameof(Validations)}");
    }
}