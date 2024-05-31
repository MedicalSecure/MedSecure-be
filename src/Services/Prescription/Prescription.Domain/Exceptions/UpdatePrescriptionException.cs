namespace Prescription.Domain.Exceptions;

public class UpdatePrescriptionStatusException : Exception
{
    public UpdatePrescriptionStatusException(string message)
        : base($"Update Prescription Status: \"{message}\"")
    {
    }

    public UpdatePrescriptionStatusException(string message, Exception innerException)
        : base($"Update Prescription Status: \"{message}\"", innerException)
    {
    }
}