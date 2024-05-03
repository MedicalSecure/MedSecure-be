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

namespace Prescription.Application.Features.Prescription.Queries.GetPrescription
{
    public class GetPrescriptionByIdHandler : IQueryHandler<GetPrescriptionByIdQuery, GetPrescriptionsResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly TypeAdapterConfig _mapsterConfig;

        public GetPrescriptionByIdHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<GetPrescriptionsResult> Handle(GetPrescriptionByIdQuery query, CancellationToken cancellationToken)
        {
            // get Prescription with single page
            // return result

            var p = await _dbContext.Prescriptions.Where(p => p.Id == query.Id)
                    .Include(p => p.Symptoms)
                    .Include(p => p.Diagnosis)
                    .Include(p => p.Register)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Comments)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Dispenses)
                    .FirstOrDefaultAsync(cancellationToken);

            var totalCount = p == null ? 0 : 1;

            if (p == null)
            {
                // Prescription not found, return not found response
                return new GetPrescriptionsResult(new PaginatedResult<PrescriptionDto>(0, 0, totalCount, []));
            }

            /*TODO fix this*/
            PrescriptionDto result = new PrescriptionDto(
                p.Id,
                p.RegisterId,
                p.DoctorId,
                p.Symptoms.ToSymptomsDto(),
                p.Diagnosis.ToDiagnosisDto(),
                p.Posology.ToPosologiesDto());

            List<PrescriptionDto> returnList = p == null ? [] : [result];
            return new GetPrescriptionsResult(
                new PaginatedResult<PrescriptionDto>(0, 1, totalCount, returnList));
        }
    }
}