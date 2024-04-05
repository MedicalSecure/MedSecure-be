﻿namespace Visit.API.EndPoints.Visit;
public record GetVisitListResponse(PaginatedResult<VisitDto> Visits);
public class GetVisitList : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/vists", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetVisitListQuery(request));

            var response = result.Adapt<GetVisitListResponse>();

            return Results.Ok(response);
        })
        .WithName("GetVisits")
        .Produces<GetVisitListResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Visits")
        .WithDescription("Get Visits");
    }
}
