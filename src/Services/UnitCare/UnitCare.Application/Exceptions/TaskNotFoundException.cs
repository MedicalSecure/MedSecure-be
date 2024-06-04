namespace UnitCare.Application.Exceptions
{


    internal class TaskNotFoundException : NotFoundException
    {
        public TaskNotFoundException(Guid id) : base("Task", id)
        {
        }
    }
}
