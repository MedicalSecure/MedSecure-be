using FluentValidation;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescription
{
    public record GetPrescriptionByStatusQuery(PrescriptionStatus Status) : IQuery<GetPrescriptionsResult>;

    public class GetPrescriptionByStatusQueryValidator : AbstractValidator<GetPrescriptionByStatusQuery>
    {
        public GetPrescriptionByStatusQueryValidator()
        {
        }
    }
}