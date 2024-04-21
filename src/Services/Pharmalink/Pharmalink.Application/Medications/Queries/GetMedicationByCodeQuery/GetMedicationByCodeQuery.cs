using BuildingBlocks.CQRS;
using Pharmalink.Application.Dtos;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByCodeQuery
{
    public record GetMedicationByCodeQuery(string code) : IQuery<GetMedicationByCodeResult>;

    public record GetMedicationByCodeResult(IEnumerable<MedicationDto> Medications);

}
