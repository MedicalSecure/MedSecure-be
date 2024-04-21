using BuildingBlocks.CQRS;
using Pharmalink.Application.Dtos;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByFormQuery
{
    public record GetMedicationByFormQuery(string form) : IQuery<GetMedicationByFormResult>;

    public record GetMedicationByFormResult(IEnumerable<MedicationDto> Medications);

}
