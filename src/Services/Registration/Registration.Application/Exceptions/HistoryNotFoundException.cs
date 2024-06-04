namespace Registration.Application.Exceptions
{
    internal class HistoryNotFoundException : NotFoundException
    {

        public HistoryNotFoundException(Guid Id) : base("History", Id)
        {
        }
    }
}
