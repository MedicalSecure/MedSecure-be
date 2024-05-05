using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis
{
    public class GetRegisterHandler(IApplicationDbContext dbContext) : IQueryHandler<GetRegisterQuery, GetRegisterResult>
    {
        public async Task<GetRegisterResult> Handle(GetRegisterQuery query, CancellationToken cancellationToken)
        {
            // get diagnosis with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Register.LongCountAsync(cancellationToken);

            var registers = await dbContext.Register
                                .Include(r => r.Patient)
                                .Include(r => r.Prescriptions)
                                    .ThenInclude(p => p.Symptoms)
                                .Include(r => r.Prescriptions)
                                    .ThenInclude(p => p.Diagnosis)
                                .Include(r => r.Prescriptions)
                                    .ThenInclude(p => p.Posology)
                                .Include(r => r.Prescriptions)
                                    .ThenInclude(p => p.Posology)
                                        .ThenInclude(p => p.Comments)
                                .Include(r => r.Prescriptions)
                                    .ThenInclude(p => p.Posology)
                                        .ThenInclude(p => p.Dispenses)
                                .Include(r => r.Prescriptions)
                                    .ThenInclude(p => p.Posology)
                                        .ThenInclude(p => p.Medication)

                                .Include(r => r.FamilyMedicalHistory)
                                    .ThenInclude(f => f.SubRiskFactor)
                                    .ThenInclude(f => f.SubRiskFactor)

                                .Include(r => r.PersonalMedicalHistory)
                                 .ThenInclude(f => f.SubRiskFactor)
                                 .ThenInclude(f => f.SubRiskFactor)

                                .Include(r => r.Diseases)
                                .ThenInclude(f => f.SubRiskFactor)
                                .ThenInclude(f => f.SubRiskFactor)

                                .Include(r => r.Allergies)
                                 .ThenInclude(f => f.SubRiskFactor)
                                 .ThenInclude(f => f.SubRiskFactor)

                                .Include(r => r.History)
                                .Include(r => r.Test)
                                .OrderBy(o => o.CreatedAt)
                                .Skip(pageSize * pageIndex)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);

            var x = new GetRegisterResult(
                new PaginatedResult<RegisterDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    registers.ToRegisterDto()));

            return x;
        }
    }
}