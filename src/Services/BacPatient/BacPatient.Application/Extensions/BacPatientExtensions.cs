using System.Linq;

namespace BacPatient.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<BacPatientDto> ToBacPatientDtos(this IEnumerable<Domain.Models.BacPatient> bacPatients)
        {
            return bacPatients.Select(d => new BacPatientDto(
                            Id: d.Id.Value,
                            Patient: new PatientDto(
                                Id:d.Patient.Id.Value,
                                 Name: d.Patient.Name,
                            DateOfBirth: d.Patient.DateOfBirth,
                            Gender: d.Patient.Gender,
                            Age: d.Patient.Age,
                            Height: d.Patient.Height,
                            Weight: d.Patient.Weight,
                            ActivityStatus: d.Patient.ActivityStatus,
                            Allergies: d.Patient.Allergies,
                            RiskFactor: d.Patient.RiskFactor,
                            FamilyHistory: d.Patient.FamilyHistory
                                ),
                            Room: new RoomDto(
                                  Id: d.Room.Id.Value,
                            number: d.Room.number,
                            status: d.Room.status,
                            beds: d.Room.Beds)
                            ,
                            UnitCare: new UnitCareDto(
                                  Id: d.UnitCare.Id.Value,
                            Title: d.UnitCare.Title,
                            Type: d.UnitCare.Type,
                            Description: d.UnitCare.Description,
                            Status: d.UnitCare.Status
                                ),
                            Bed: d.Bed,
                            Served: d.Served,
                            ToServe: d.ToServe,
                            Status: d.Status,
                            ServingDate: d.ServingDate,
                            Medicines: d.Medicines.Select(m => new MedicineDto(
                                             Id: m.Id.Value,
                                             Name: m.Name,
                                             Form: m.Forme,
                                             Root : m.Root, 
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
