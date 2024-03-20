
namespace Diet.Application.Exceptions
{
    internal class DietNotFoundException : NotFoundException
    {
        public DietNotFoundException(Guid id) : base("Diet", id)
        {
        }
    }
}