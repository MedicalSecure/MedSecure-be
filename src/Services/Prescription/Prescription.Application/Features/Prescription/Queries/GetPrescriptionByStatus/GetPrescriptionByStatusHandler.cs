using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescription
{
    public class GetPrescriptionByStatusHandler : IQueryHandler<GetPrescriptionByStatusQuery, GetPrescriptionsResult>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetPrescriptionByStatusHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetPrescriptionsResult> Handle(GetPrescriptionByStatusQuery query, CancellationToken cancellationToken)
        {
            // get Prescription with single page
            // return result

            var p = await _dbContext.Prescriptions.Where(p => p.Status == query.Status)
                   .Include(p => p.Diet)
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
                return new GetPrescriptionsResult(new PaginatedResult<PrescriptionDto>(0, 0, totalCount, []));
            }

            /*TODO fix this*/
            PrescriptionDto result = p.ToPrescriptionDto();

            List<PrescriptionDto> returnList = p == null ? [] : [result];
            return new GetPrescriptionsResult(
                new PaginatedResult<PrescriptionDto>(0, 1, totalCount, returnList));
        }
    }
}