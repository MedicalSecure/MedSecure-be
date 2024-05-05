using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Tests.Queries.GetTests;

namespace Registration.Api.Endpoints.Test
{
    public record GetTestsResponse(PaginatedResult<TestDto> Tests);
    public class GetTests : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/tests", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetTestsQuery(paginationRequest));

                var response = result.Adapt<GetTestsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetTests")
            .Produces<GetTestsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Tests")
            .WithDescription("Get Tests");
        }
    }
}
