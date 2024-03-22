
namespace Diet.API.Endpoints
{
    //- Accepts a patient ID as a parameter.
    //- Constructs a DeletePatientCommand with the patient ID.
    //- Sends the command for processing.
    //- Returns a success or error response based on the outcome.

    //public class DeletePatient : ICarterModule
    //{
    //    public void AddRoutes(IEndpointRouteBuilder app)
    //    {
    //        app.MapDelete("/patients/{patientId}", async (string patientId, ISender sender) =>
    //        {
    //            var result = await sender.Send(new DeletePatientCommand(patientId));

    //            if (result)
    //            {
    //                return Results.Ok("Patient deleted successfully");
    //            }
    //            else
    //            {
    //                return Results.NotFound("Patient not found");
    //            }
    //        })
    //        .WithName("DeletePatient")
    //        .Produces(StatusCodes.Status200OK)
    //        .Produces(StatusCodes.Status404NotFound)
    //        .WithSummary("Delete Patient")
    //        .WithDescription("Delete Patient by ID");
    //    }
    //}
}