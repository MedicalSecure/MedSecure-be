using BacPatient.Application.BacPatient.Commands.AddNote;
using BacPatient.Application.BacPatient.Commands.UpdateBacPatientStatus;
using BacPatient.Domain.Enums;

namespace BacPatient.Api.Endpoints.BacPatient
{
    public record AddNoteRequest(Guid Id, string Note);
    public record AddNoteResponse(bool IsSuccess);
    public class AddNoteToMedecine : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/bacpatient/addNote", async (AddNoteRequest request, ISender sender) =>
            {
                var command = request.Adapt<AddNoteCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<AddNoteResponse>();

                return Results.Ok(response);
            })
            .WithName("AddNote")
            .Produces<AddNoteResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update BacPatient")
            .WithDescription("Update BacPatient");
        }
    }
}
