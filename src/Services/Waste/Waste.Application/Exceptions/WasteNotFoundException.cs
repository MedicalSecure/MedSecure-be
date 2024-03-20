
namespace Waste.Application.Exceptions;

public class WasteNotFoundException : NotFoundException
{
    public WasteNotFoundException(Guid id) : base("Waste", id)
    {
    }
}