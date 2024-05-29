namespace Prescription.Application.Contracts
{
    public interface IPatientService
    {
        Task<PatientDTO> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken);

        Task<IEnumerable<PatientDTO>> GetPatientsAsync(CancellationToken cancellationToken);

        // Add more methods as needed
    }
}