namespace Registration.Application.Exceptions
{
    internal class TestNotFoundException : NotFoundException
    {

        public TestNotFoundException(Guid Id) : base("Test", Id)
        {
        }
    }
}
