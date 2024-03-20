
namespace Diet.Application.Exceptions
{
    public class FoodNotFoundException : NotFoundException
    {
        public FoodNotFoundException(Guid id) : base("Food", id)
        {
        }
    }
}