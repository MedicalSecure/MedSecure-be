
namespace Diet.Application.Diets.Queries.GetFoodByNameQuery
{
    public record GetFoodByNameQuery(Guid id) : IQuery<GetDietByPatientIdResult>;

    public record GetDietByPatientIdResult(IEnumerable<DietDto> Diets);
   
}
