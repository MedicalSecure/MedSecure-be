namespace BacPatient.Application.Extensions
{
    public static partial class BacPatientExtensions
    {
        public static IEnumerable<BacPatientDto> ToBacPatientDtos(this IEnumerable<Domain.Models.BacPatient> bacPatients)
        {
            return bacPatients.Select(d => new BacPatientDto(
                            Id: d.Id.Value,
                            PatientId: d.PatientId.Value,
                            RoomId: d.RoomId.Value,
                            UnitCareId: d.UnitCareId.Value,
                            Bed: d.Bed,
                            Served: d.Served,
                            ToServe: d.ToServe,
                            Status: d.Status,
                            ServingDate: d.ServingDate,
                            Medicines: d.Medicines.Select(m => new MedicineDto(
                                             Id: m.Id.Value,
                                             Name: m.Name,
                                             Form: m.Forme,
                                             Dose: m.Dose,
                                             Unit: m.Unit,
                                             DateExp: m.DateExp,
                                             Stock: m.Stock,
                                             Note: m.Note,
                                             Posology: m.Posologies.Select(mi => new PosologyDto(
                                                 Id: mi.Id.Value,
                                                 StartDate: mi.StartDate,
                                                 EndDate: mi.EndDate,
                                                 QuantityAE: mi.QuantityAE,
                                                 QuantityBE: mi.QuantityBE,
                                                 IsPermanent: mi.IsPermanent,
                                                 Hours: mi.Hours
                                             )).ToList()
                                         )).ToList()
                        ));
        }
    }
}
