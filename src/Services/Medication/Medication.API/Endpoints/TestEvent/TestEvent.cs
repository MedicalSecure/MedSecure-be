using Medication.Application.Test;

namespace Medication.API.Endpoints.TestEvent
{
    public class testEvents : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/testEvents/{name}", async (string eventName, ISender sender) =>
            {
                var validName = eventName == "v" ? "validPrescriptionEvent" : "DiscontinuedPrescriptionEvent";
                var result = await sender.Send(new TestEventQuery(validName));
                return Results.Ok("sent : " + validName);
            })
            .WithName($"Get {nameof(testEvents)}")
            .Produces<string>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary($"Get test")
            .WithDescription($"Get test");
        }
    }
}
