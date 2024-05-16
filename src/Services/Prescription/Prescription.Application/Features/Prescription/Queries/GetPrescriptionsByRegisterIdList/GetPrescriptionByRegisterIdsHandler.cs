using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.DTOs;
using Prescription.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterIdList
{
    public class GetPrescriptionByRegisterIdsHandler : IQueryHandler<GetPrescriptionsByRegisterIdsQuery, GetPrescriptionsByRegisterIdsResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly TypeAdapterConfig _mapsterConfig;

        public GetPrescriptionByRegisterIdsHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<GetPrescriptionsByRegisterIdsResult> Handle(GetPrescriptionsByRegisterIdsQuery query, CancellationToken cancellationToken)
        {
            List<Guid> registerIds = query.registerIds;
            Dictionary<Guid, List<PrescriptionDto>> prescriptionsByRegisterIds = new Dictionary<Guid, List<PrescriptionDto>>();

            try
            {
                foreach (var registerId in registerIds)
                {
                    var prescriptions = await _dbContext.Prescriptions
                        .Where(p => p.RegisterId == RegisterId.Of(registerId))
                        .Include(p => p.Symptoms)
                        .Include(p => p.Diagnosis)
                        .Include(p => p.Posology)
                        .ThenInclude(posology => posology.Comments)
                        .Include(p => p.Posology)
                        .ThenInclude(posology => posology.Dispenses)
                        .ToListAsync(cancellationToken);

                    List<PrescriptionDto> prescriptionDtos = prescriptions.Select(p => new PrescriptionDto(
                        Id: p.Id.Value,
                        RegisterId: p.RegisterId.Value,
                        DoctorId: p.DoctorId.Value,
                        Symptoms: p.Symptoms.ToSymptomsDto(),
                        Diagnoses: p.Diagnosis.ToDiagnosisDto(),
                        Posologies: p.Posology.ToPosologiesDto(),
                        CreatedAt: p.CreatedAt ?? DateTime.UtcNow,
                        UnitCareId: p.UnitCareId?.Value,
                        DietId: p.DietId?.Value,
                        LastModified: p.LastModified,
                        CreatedBy: p.CreatedBy,
                        LastModifiedBy: p.LastModifiedBy
                    )).ToList();

                    prescriptionsByRegisterIds[registerId] = prescriptionDtos;
                }
            }
            catch (Exception x)
            {
                throw x;
            }

            return new GetPrescriptionsByRegisterIdsResult(prescriptionsByRegisterIds);
        }
    }
}