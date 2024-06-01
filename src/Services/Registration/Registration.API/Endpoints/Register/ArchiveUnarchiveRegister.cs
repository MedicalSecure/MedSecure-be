using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Registers.Commands.ArchiveUnarchiveRegister;
using Registration.Domain.Enums;

namespace Registration.Api.Endpoints.Register
{
    public record ArchiveUnarchiveRegisterRequest(Guid registerId, RegisterStatus registerStatus);
    public record ArchiveUnarchiveRegisterResponse(string registerId);

    public class ArchiveUnarchiveRegister : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/registers/status", async (ArchiveUnarchiveRegisterRequest request, ISender sender) =>
            {
                if (request != null && request.registerId != Guid.Empty)
                {
                    try
                    {
                        var command = new ArchiveUnarchiveRegisterCommand(request.registerId, request.registerStatus);
                        var result = await sender.Send(command);

                        var response = new ArchiveUnarchiveRegisterResponse(result.registerId);
                        return Results.Created($"/registers/status/{response.registerId}", response);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message, ex.InnerException?.ToString() ?? ex.Message, 500);
                    }
                }
                else
                {
                    if (request == null) return Results.BadRequest("Request object is null.");
                    if (request.registerId == Guid.Empty) return Results.BadRequest("RegisterId is required.");
                    return Results.BadRequest("Bad request");
                }
            })
            .WithName("ArchiveUnarchiveRegister")
            .Produces<ArchiveUnarchiveRegisterResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Archive/Unarchive Register")
            .WithDescription("Archive/Unarchive Register");
        }
    }
}