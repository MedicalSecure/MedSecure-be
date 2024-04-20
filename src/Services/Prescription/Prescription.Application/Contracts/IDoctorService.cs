using Prescription.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Contracts
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetDoctorByIdAsync(Guid DoctorId, CancellationToken cancellationToken);

        Task<IEnumerable<DoctorDto>> GetDoctorsAsync(CancellationToken cancellationToken);

        // Add more methods as needed
    }
}