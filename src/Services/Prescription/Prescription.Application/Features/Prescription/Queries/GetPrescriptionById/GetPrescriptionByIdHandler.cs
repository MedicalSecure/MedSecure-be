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

            var p = await _dbContext.Prescriptions.Where(p => p.Id == PrescriptionId.Of(query.Id))
                   .Include(p => p.Diet)
                    .Include(p => p.Validation)
                    .Include(p => p.Symptoms)
                    .Include(p => p.Diagnosis)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Comments)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Dispenses)
                    .Include(p => p.Posology)
                    .ThenInclude(posology => posology.Medication)
                   .FirstOrDefaultAsync(cancellationToken);

            var totalCount = p == null ? 0 : 1;

            if (p == null)
            {
                // Prescription not found, return not found response
                return new GetPrescriptionsResult(new PaginatedResult<PrescriptionDTO>(0, 0, totalCount, []));
            }

            /*TODO fix this*/
            PrescriptionDTO result = p.ToPrescriptionDto();

            List<PrescriptionDTO> returnList = p == null ? [] : [result];
            return new GetPrescriptionsResult(
                new PaginatedResult<PrescriptionDTO>(0, 1, totalCount, returnList));
        }
    }
}