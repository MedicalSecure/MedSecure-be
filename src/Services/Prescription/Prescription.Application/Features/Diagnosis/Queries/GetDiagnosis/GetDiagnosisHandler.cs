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
    public class GetDiagnosisHandler(IApplicationDbContext dbContext) : IQueryHandler<GetDiagnosisQuery, GetDiagnosisResult>
    {
        public async Task<GetDiagnosisResult> Handle(GetDiagnosisQuery query, CancellationToken cancellationToken)
        {
            // get diagnosis with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Diagnosis.LongCountAsync(cancellationToken);

            var diagnosis = await dbContext.Diagnosis
                           .OrderBy(o => o.Name)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            return new GetDiagnosisResult(
                new PaginatedResult<DiagnosisDTO>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    diagnosis.ToDiagnosisDto()));
        }
    }
}