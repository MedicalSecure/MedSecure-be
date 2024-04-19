using BuildingBlocks.Exceptions;


namespace Registration.Application.Exceptions
{
    internal class RegisterNotFoundException : NotFoundException
    {
        public RegisterNotFoundException(Guid Id) : base("Regitser", Id)
        {
        }
    }
}
