using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Histories.Queries.GetHistories;

namespace Registration.Api.Endpoints.History
{
    public record GetHistoriesResponse(PaginatedResult<HistoryDto> Histories);
    public class GetHistories : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/histories", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetHistoriesQuery(paginationRequest));

                var response = result.Adapt<GetHistoriesResponse>();

                return Results.Ok(response);
            })
            .WithName("GetHistories")
            .Produces<GetHistoriesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Histories")
            .WithDescription("Get Histories");
        }
    }
}
