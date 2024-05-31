using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Registration.Application.Data;
using Registration.Application.Dtos;
using Registration.Application.Extensions;

namespace Registration.Application.Patients.Queries.GetPatients
{
    public class GetPatientsHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetPatientsQuery, GetPatientsResult>
    {
        public async Task<GetPatientsResult> Handle(GetPatientsQuery query, CancellationToken cancellationToken)

        {
            // get patients with pagination
            // return result
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Patients.LongCountAsync(cancellationToken);

            var Registers = await dbContext.Registers
                .Where(r => r.Status == RegisterStatus.Archived)
                .ToListAsync();
            var patients = await dbContext.Patients
                              .OrderBy(o => o.DateOfBirth)
                              .Skip(pageSize * pageIndex)
                              .Take(pageSize)
                              .ToListAsync(cancellationToken);

            var patientsDto = patients.Select(patient =>
            {
                if (Registers.Any(r => r.PatientId == patient.Id))
                    return patient.ToPatientDto(archived: true);
                else
                    return patient.ToPatientDto(archived: false);
            });

            return new GetPatientsResult(
                new PaginatedResult<PatientDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    patientsDto));
        }
    }
}