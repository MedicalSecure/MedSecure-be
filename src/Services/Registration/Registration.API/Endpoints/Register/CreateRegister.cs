using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Registers.Commands.CreateRegister;

namespace Registration.Api.Endpoints.Register
{
    public record CreateRegisterRequest(RegisterDto register);
    public record CreateRegisterResponse(string Id);

    public class CreateRegister : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/registers", async (CreateRegisterRequest request, ISender sender) =>
            {
                if (request != null)
                {
                    //    var command = request.Adapt<CreateRegisterCommand>();
                    CreateRegisterCommand command = new CreateRegisterCommand(request.register);
                    var result = await sender.Send(command);

                    var response = result.Adapt<CreateRegisterResponse>();
                    return Results.Created($"/registers/{response.Id}", response);
                }
                else
                {
                    return Results.BadRequest("Request object is null.");
                }
            })
            .WithName("CreateRegister")
            .Produces<CreateRegisterResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Register")
            .WithDescription("Create Register");
        }
    }
}