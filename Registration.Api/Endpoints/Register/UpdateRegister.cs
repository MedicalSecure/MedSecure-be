using Carter;
using Mapster;
using MediatR;
using Registration.Application.Dtos;
using Registration.Application.Register.Commands.UpdateRegister;

namespace Registration.Api.Endpoints.Register
{
    public record UpdateRegisterRequest(RegisterDto Register);

    public record UpdateRegisterResponse(bool IsSuccess);
    public class UpdateRegister : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut(
                    "/registers",
                    async (UpdateRegisterRequest request, ISender sender) =>
                    {
                        var command = request.Adapt<UpdateRegisterCommand>();

                        var result = await sender.Send(command);

                        var response = result.Adapt<UpdateRegisterResponse>();

                        return Results.Ok(response);
                    }
                )
                .WithName("UpdateRegister")
                .Produces<UpdateRegisterResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Update Register")
                .WithDescription("Update Register");
        }
    }
}
