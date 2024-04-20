using Prescription.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Contracts
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(Guid patientId, CancellationToken cancellationToken);

        Task<IEnumerable<PatientDto>> GetPatientsAsync(CancellationToken cancellationToken);

        // Add more methods as needed
    }
}