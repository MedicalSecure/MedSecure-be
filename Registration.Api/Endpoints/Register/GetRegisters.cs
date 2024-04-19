using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Register.Queries.GetRegisters;

namespace Registration.Api.Endpoints.Register
{
    public record GetRegistersResponse(PaginatedResult<RegisterDto> Registers);
    public class GetRegisters : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/registers", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetRegistersQuery(paginationRequest));

                var response = result.Adapt<GetRegistersResponse>();

                return Results.Ok(response);
            })
            .WithName("GetRegisters")
            .Produces<GetRegistersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Registers")
            .WithDescription("Get Registers");
        }
    }
}
