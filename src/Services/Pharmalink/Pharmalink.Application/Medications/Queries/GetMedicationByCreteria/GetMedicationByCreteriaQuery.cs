using BuildingBlocks.CQRS;
using Pharmalink.Application.Dtos;

namespace Pharmalink.Application.Medications.Queries.GetMedicationByCreteria
{
   
    public record GetMedicationByCreteriaQuery(Pharmalink.Application.Dtos.CreteriaDto creteria) : IQuery<GetMedicationByCreteriaResult>;
    
    public record GetMedicationByCreteriaResult(IEnumerable<MedicationDto> Medications);


}
