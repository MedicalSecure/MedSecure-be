
namespace Registration.Application.Exceptions
{
    internal class PatientNotFoundException : NotFoundException
    {
        public PatientNotFoundException(Guid Id) : base("Patient" , Id)
        {
        }
    }
}
