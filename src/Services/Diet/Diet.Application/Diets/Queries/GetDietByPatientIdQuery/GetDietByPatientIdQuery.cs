
namespace Diet.Application.Diets.Queries.GetDietByIdQuery
{
    public record GetFoodByNameQuery(Guid id) : IQuery<GetDietByPatientIdResult>;

    public record GetDietByPatientIdResult(IEnumerable<DietDto> Diets);
   
}
