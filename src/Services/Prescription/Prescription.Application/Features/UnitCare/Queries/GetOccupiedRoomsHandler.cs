using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.UnitCare.Queries
{
    public class GetOccupiedRoomsHandler : IQueryHandler<GetOccupiedRoomsQuery, GetOccupiedRoomsResult>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetOccupiedRoomsHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetOccupiedRoomsResult> Handle(GetOccupiedRoomsQuery query, CancellationToken cancellationToken)
        {
            // get diets with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await _dbContext.Prescriptions.LongCountAsync(cancellationToken);

            List<Domain.Entities.Prescription> prescriptions;

            if (query.PaginationRequest.PageSize == -1)
            {
                //get all
                prescriptions = await _dbContext.Prescriptions
                           .OrderBy(o => o.CreatedAt)
                           .Where(pr => (pr.Status == PrescriptionStatus.Active || pr.Status == PrescriptionStatus.Pending))
                           .ToListAsync(cancellationToken);
            }
            else
            {
                //the default fetch
                prescriptions = await _dbContext.Prescriptions
                           .OrderBy(o => o.CreatedAt)
                           .Where(pr => (pr.Status == PrescriptionStatus.Active || pr.Status == PrescriptionStatus.Pending))
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);
            }

            var roomsIds = prescriptions.Select(p => p.BedId).OfType<EquipmentId>().ToList() ?? [];
            return new GetOccupiedRoomsResult(
                new PaginatedResult<EquipmentId>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    roomsIds));
        }
    }
}