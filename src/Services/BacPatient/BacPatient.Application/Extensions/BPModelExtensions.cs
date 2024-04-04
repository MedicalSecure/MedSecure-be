
namespace BacPatient.Application.Extensions
{
    public static partial class BPModelExtensions
    {
        public static IEnumerable<BPModelDto> TobPModelDtos(this IEnumerable<Domain.Models.BPModel> diets)
        {
            return diets.OrderBy(d => d.bed)
                        .Select(d => new BPModelDto(
                            Id: d.Id.Value,
                            PatientId: d.PatientId.Value,
                            RoomId: d.RoomId.Value,
                            UnitCareId: d.UnitCareId.Value,
                            Bed: d.bed,
                            Served: d.served,
                            ToServe: d.toServe,
                            Status: d.status,
                            ServingDate: d.servingDate,
                            Medicines: d.Medicines.OrderBy(m => m.dose)
                                         .Select(m => new MedicineDto(
                                             Id: m.Id.Value,
                                             Name: m.name,
                                             Form: m.forme,
                                             dose: m.dose,
                                             Unit: m.unit,
                                             DateExp: m.dateExp,
                                             Stock: m.stock,
                                             Note: m.note,
                                             Posology: m.Posologies.Select(mi => new PosologyDto(
                                                 Id: mi.Id.Value,
                                                 StartDate: mi.startDate,
                                                 EndDate: mi.endDate,
                                                 QuantityAE: mi.quantityAE , 
                                                 QuantityBE:mi.quantityBE , 
                                                 isPermanent: mi.isPermanent ,
                                                 Hours: mi.hours
                                             )).ToList()
                                         )).ToList()
                        )); ;
        }
    }
}
