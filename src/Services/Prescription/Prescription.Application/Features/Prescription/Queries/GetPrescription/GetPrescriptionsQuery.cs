using FluentValidation;

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