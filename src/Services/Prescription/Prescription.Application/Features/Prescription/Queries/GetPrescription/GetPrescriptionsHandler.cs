using Prescription.Application.Contracts;
using Prescription.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescription
{
    public class GetPrescriptionsHandler : IQueryHandler<GetPrescriptionsQuery, GetPrescriptionsResult>
    {
        private readonly IApplicationDbContext _dbContext;

        //private readonly IDoctorService _doctorService;
        private readonly TypeAdapterConfig _mapsterConfig;

        public GetPrescriptionsHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<GetPrescriptionsResult> Handle(GetPrescriptionsQuery query, CancellationToken cancellationToken)
        {
            // get diets with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await _dbContext.Prescriptions.LongCountAsync(cancellationToken);

            var prescriptions = await _dbContext.Prescriptions
                           .Include(p => p.Symptoms)
                           .Include(p => p.Diagnosis)
                           .Include(p => p.Register)
                           .Include(p => p.Doctor)
                           .Include(p => p.Posology)
                           .ThenInclude(posology => posology.Comments)
                           .Include(p => p.Posology)
                           .ThenInclude(posology => posology.Dispenses)
                           .Include(p => p.Posology)
                           .ThenInclude(posology => posology.Medication)
                           .OrderBy(o => o.CreatedAt)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);
            var prescriptionDtos = prescriptions.ToPrescriptionsDto();

            // await prescriptionDtos.Select<PrescriptionDto>(p => p);

            return new GetPrescriptionsResult(
                new PaginatedResult<PrescriptionDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    prescriptionDtos));
        }
    }
}