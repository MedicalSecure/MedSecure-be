
namespace BacPatient.Infrastructure.Data.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message)
        : base($"Infrastructure Exception: \"{message}\" throws from Infrastructure Layer.")
        {
        }
    }
}
