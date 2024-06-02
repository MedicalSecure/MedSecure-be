﻿using Visit.Application.Activity.Queries.GetActivities;

namespace Visit.API.EndPoints.Activities
{
    public record GetActivitiesResponse(PaginatedResult<ActivityDto> Activities);

    public class GetActivities : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/v1/visits/Activities", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetActivitiesQuery(paginationRequest));

                var response = result.Adapt<GetActivitiesResponse>();

                return Results.Ok(response);
            })
            .WithName($"Get {nameof(Activities)}")
            .Produces<GetActivitiesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary($"Get {nameof(Activities)}")
            .WithDescription($"Get {nameof(Activities)}");
        }
    }
}
