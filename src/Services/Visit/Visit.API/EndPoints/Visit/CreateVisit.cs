using Mapster;
using Visit.Application.Dtos;
using Visit.Application.Visits.Commands.CreateVisit;

namespace Visit.API.EndPoints.Visit;

public record CreateVisitRequest (VisitDto Visit);
public record CreateVisitResponse(Guid Id);

public class CreateVisit : ICarterModule
{
    public void AddRoutes (IEndpointRouteBuilder app)
    {
        app.MapPost("/visits",async(CreateVisitRequest request , ISender sender)=>
        {
            var command =request.Adapt<CreateVisitCommand>();
            var result =await sender.Send(command);
            var response =result.Adapt<CreateVisitResponse>();
            return Results.Created($"/visits/{response.Id}",response);
        })

         .WithName("CreateVisit")
        .Produces<CreateVisitResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Visit")
        .WithDescription("Create Visit");

    }
}
