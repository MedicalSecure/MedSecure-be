using FluentValidation;
using Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescription
{
    public record GetPrescriptionsQuery(PaginationRequest PaginationRequest) : IQuery<GetPrescriptionsResult>;
    public record GetPrescriptionsResult(PaginatedResult<PrescriptionDto> Prescriptions);

    public class GetPrescriptionsQueryValidator : AbstractValidator<GetPrescriptionsQuery>
    {
        public GetPrescriptionsQueryValidator()
        {
        }
    }
}