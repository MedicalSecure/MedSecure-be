using BuildingBlocks.CQRS;
using Pharmalink.Application.Dtos;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByNameQuery
{
    public record GetMedicationByNameQuery(string name) : IQuery<GetMedicationByNameResult>;

    public record GetMedicationByNameResult(IEnumerable<MedicationDto> Medications);

}
