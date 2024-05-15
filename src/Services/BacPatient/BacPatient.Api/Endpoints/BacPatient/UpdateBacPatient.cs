using BacPatient.Application.BacPatient.Commands.UpdateBacPatient;

namespace BacPatient.Api.Endpoints.BacPatient
{
    
    public record UpdateBacPatientRequest(BacPatientDto BacPatient);
    public record UpdateBacPatientResponse(bool IsSuccess);

    public class UpdateBacPatient : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/v1/bacPatient", async (UpdateBacPatientRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateBacPatientCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateBacPatientResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateBacPatient")
            .Produces<UpdateBacPatientResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update BacPatient")
            .WithDescription("Update BacPatient");
        }
    }
}
