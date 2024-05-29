using FluentValidation;
using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterId
{
    public record GetPrescriptionByRegisterIdQuery(Guid RegisterId) : IQuery<GetPrescriptionsResult>;
    public record GetPrescriptionsResult(PaginatedResult<PrescriptionDTO> Prescriptions);

    public class GetPrescriptionByRegisterIdQueryValidator : AbstractValidator<GetPrescriptionByRegisterIdQuery>
    {
        public GetPrescriptionByRegisterIdQueryValidator()
        {
        }
    }
}