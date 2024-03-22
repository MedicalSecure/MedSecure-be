
namespace Diet.API.Endpoints.Diet
{
    //- Accepts a UpdateDietRequest.
    //- Maps the request to an UpdateDietCommand.
    //- Sends the command for processing.
    //- Returns a success or error response based on the outcome.

    public record UpdateDietRequest(DietDto Diet);
    public record UpdateDietResponse(bool IsSuccess);

    public class UpdateDiet : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/diets", async (UpdateDietRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateDietCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateDietResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateDiet")
            .Produces<UpdateDietResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Diet")
            .WithDescription("Update Diet");
        }
    }
}