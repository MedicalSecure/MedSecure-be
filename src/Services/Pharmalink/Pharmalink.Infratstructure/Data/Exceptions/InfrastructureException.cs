namespace Pharmalink.Infratstructure.Data.Exceptions;

public class InfrastructureException : Exception
{
    public InfrastructureException(string message)
    : base($"Infrastructure Exception: \"{message}\" throws from Infrastructure Layer.")
    {
    }
}
