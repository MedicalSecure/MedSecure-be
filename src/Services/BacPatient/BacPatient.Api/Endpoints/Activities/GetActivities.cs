﻿using BacPatient.Application.Activity.Queries;

namespace BacPatient.Api.Endpoints.Activities
{
    public record GetActivitiesResponse(PaginatedResult<ActivityDto> Activities);

    public class GetActivities : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/Prescription/Activities", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
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
