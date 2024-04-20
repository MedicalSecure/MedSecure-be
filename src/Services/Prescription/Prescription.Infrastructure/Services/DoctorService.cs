using Prescription.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Mapster;
using BuildingBlocks.Pagination;
using Prescription.Application.Dtos;
using Prescription.Application.Contracts;

namespace Prescription.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient _httpClient;
        private readonly TypeAdapterConfig _mapsterConfig;

        public DoctorService(HttpClient httpClient, TypeAdapterConfig mapsterConfig)
        {
            _httpClient = httpClient;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(Guid DoctorId, CancellationToken cancellationToken)
        {
            /*            // Make an HTTP request to the Doctor microservice to fetch Doctor data by ID
                        var DoctorResponse = await _httpClient.GetFromJsonAsync<GetDoctorResponse>($"/api/Doctor/{DoctorId}", cancellationToken);

                        // Map the response to a DoctorDto using Mapster
                        var DoctorDto = DoctorResponse.Adapt<DoctorDto>(_mapsterConfig);

                        return DoctorDto;*/

            var DoctorResponse = await _httpClient.GetFromJsonAsync<DoctorDto>($"/api/Doctor/{DoctorId}", cancellationToken);
            return DoctorResponse;
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsAsync(CancellationToken cancellationToken)
        {
            // Make an HTTP request to the Doctor microservice to fetch all Doctors
            var DoctorsResponse = await _httpClient.GetFromJsonAsync<GetDoctorResponse>("/api/Doctor", cancellationToken);

            // Map the response to a collection of DoctorDto using Mapster
            var DoctorDtos = DoctorsResponse.Doctors.Adapt<IEnumerable<DoctorDto>>(_mapsterConfig);

            return DoctorDtos;
        }
    }

    public record GetDoctorResponse(PaginatedResult<DoctorDto> Doctors);
}