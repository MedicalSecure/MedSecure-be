

namespace BacPatient.Application.Exceptions
{
    internal class BPNotFoundException : NotFoundException
    {
        public BPNotFoundException(Guid id) : base("BPModel", id)
        {
        }
    }
}