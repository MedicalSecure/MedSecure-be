using FluentValidation;

namespace Prescription.Application.Features.Prescription.Queries.GetPrescriptionByRegisterIdList
{
    public record GetPrescriptionsByRegisterIdsQuery(List<Guid> registerIds) : IQuery<GetPrescriptionsByRegisterIdsResult>;
    public record GetPrescriptionsByRegisterIdsResult(Dictionary<Guid, List<PrescriptionDTO>> PrescriptionsByRegisterId);

    public class GetPrescriptionByRegisterIdListQueryValidator : AbstractValidator<GetPrescriptionsByRegisterIdsQuery>
    {
        public GetPrescriptionByRegisterIdListQueryValidator()
        {
        }
    }
}