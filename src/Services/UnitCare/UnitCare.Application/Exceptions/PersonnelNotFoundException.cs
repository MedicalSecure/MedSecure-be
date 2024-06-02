namespace UnitCare.Application.Exceptions
{

    internal class PersonnelNotFoundException : NotFoundException
    {
        public PersonnelNotFoundException(Guid id) : base("Personnel", id)
        {
        }
    }
}
