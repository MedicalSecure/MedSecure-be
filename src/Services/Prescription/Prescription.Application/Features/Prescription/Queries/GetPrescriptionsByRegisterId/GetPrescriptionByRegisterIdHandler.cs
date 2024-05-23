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

namespace Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterId
{
    public class GetPrescriptionByRegisterIdHandler : IQueryHandler<GetPrescriptionByRegisterIdQuery, GetPrescriptionsResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly TypeAdapterConfig _mapsterConfig;

        public GetPrescriptionByRegisterIdHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<GetPrescriptionsResult> Handle(GetPrescriptionByRegisterIdQuery query, CancellationToken cancellationToken)
        {
            // get Prescription with single page
            // return result

            var prescriptions = await _dbContext.Prescriptions.Where(p => p.RegisterId == RegisterId.Of(query.RegisterId))
                   .Include(p => p.Diet)
                    .Include(p => p.Symptoms)
                    .Include(p => p.Diagnosis)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Comments)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Dispenses)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Medication)
                   .ToListAsync(cancellationToken);

            var totalCount = prescriptions.Count;

            /*TODO fix this*/
            List<PrescriptionDto> prescriptionDTOs = prescriptions.Select(p => p.ToPrescriptionDto()).ToList();

            var pageSize = totalCount;
            return new GetPrescriptionsResult(
                new PaginatedResult<PrescriptionDto>(0, pageSize, totalCount, prescriptionDTOs));
        }
    }
}