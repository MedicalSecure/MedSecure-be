
namespace Visit.Application.Exceptions;

public class VisitNotFoundException :NotFoundException
{
    public VisitNotFoundException(Guid id) : base("Visit", id)
    {

    }
}
