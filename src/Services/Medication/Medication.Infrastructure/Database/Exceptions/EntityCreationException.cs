namespace Medication.Infrastructure.Database.Exceptions;


public class EntityCreationException : InfrastructureException
{
    public EntityCreationException(string entityType, string message)
        : base($"Error creating {entityType}: \"{message}\"")
    {
    }
}
