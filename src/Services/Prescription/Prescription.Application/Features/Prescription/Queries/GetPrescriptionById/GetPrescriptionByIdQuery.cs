using FluentValidation;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescription
{
    public record GetPrescriptionByIdQuery(Guid Id) : IQuery<GetPrescriptionsResult>;

    public class GetPrescriptionByIdQueryValidator : AbstractValidator<GetPrescriptionByIdQuery>
    {
        public GetPrescriptionByIdQueryValidator()
        {
        }
    }
}