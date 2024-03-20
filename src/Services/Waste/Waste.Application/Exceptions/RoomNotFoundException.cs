
namespace Waste.Application.Exceptions;

public class RoomNotFoundException : NotFoundException
{
    public RoomNotFoundException(Guid id) : base("Room", id)
    {
    }
}