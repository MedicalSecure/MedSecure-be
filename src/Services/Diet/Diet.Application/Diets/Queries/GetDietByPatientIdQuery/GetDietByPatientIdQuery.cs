
namespace Diet.Application.Diets.Queries.GetDietByPatientIdQuery
{
    public record GetDietByPatientIdQuery(Guid id) : IQuery<GetDietByPatientIdResult>;

    public record GetDietByPatientIdResult(IEnumerable<DietDto> Diets);
   
}
