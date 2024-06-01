using BuildingBlocks.Pagination;
using Carter;
using Mapster;
using MediatR;
using Registration.Api.Endpoints.History;
using Registration.Application.Dtos;
using Registration.Application.Histories.Commands.CreateHistory;
using Registration.Application.Registers.Queries.GetRegisters;
using Registration.Application.Registers.Queries.GetRegistersById;

namespace Registration.Api.Endpoints.Register
{
    public record GetRegistersResponse(PaginatedResult<RegisterDto> Registers);
    public record GetRegistersByIdResponse(RegisterDto Register);

    public class GetRegisters : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Get all
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

            //Get by id
            app.MapGet("/registers/{id}", async (Guid id, ISender sender) =>
            {
                if (id != Guid.Empty)
                {
                    try
                    {
                        var result = await sender.Send(new GetRegistersByIdQuery(id));
                        var response = result.Adapt<GetRegistersByIdResponse>();
                        return Results.Ok(response);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem( ex.InnerException?.ToString() ?? ex.Message,ex.Message, 500);
                    }
                }
                else
                {
                    return Results.BadRequest("Request object or RegisterId is null.");
                }
            })
            .WithName("GetRegisterById")
            .Produces<GetRegistersByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Register by ID")
            .WithDescription("Get a specific register by its ID");
        }
    }
}