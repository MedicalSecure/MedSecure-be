using System.Linq;

namespace BacPatient.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<BacPatientDto> ToBacPatientDtos(this IEnumerable<Domain.Models.BacPatient> bacPatients)
        {
            return bacPatients.Select(d => new BacPatientDto(
                            Id: d.Id,
                            Patient: new PatientDto(id: d.Patient.Id,
                patientName: d.Patient.PatientName,
                dateOfBirth: d.Patient.DateOfBirth.Date,
                gender: d.Patient.Gender,
                height: d.Patient.Height,
                weight: d.Patient.Weight,
                register: d.Patient.Register,
                riskFactor: d.Patient.RiskFactor,
                disease: d.Patient.Disease
                                ),
                            Room: new RoomDto(
                                  Id: d.Room.Id.Value,
                            Number: d.Room.Number,
                            Status: d.Room.Status,
                            Beds: d.Room.Beds)
                            ,
                            UnitCare: new UnitCareDto(
                                  Id: d.UnitCare.Id.Value,
                            Title: d.UnitCare.Title,
                            Type: d.UnitCare.Type,
                            Description: d.UnitCare.Description,
                            Status: d.UnitCare.Status
                                ),
                            Bed: d.Bed,
                            NurseId:d.NurseId,
                            Served: d.Served,
                            ToServe: d.ToServe,
                            Status: d.Status,
                            ServingDate: d.ServingDate,
                            Medicines: d.Medicines.Select(m => new MedicationDto(
Id: m.Id,
                Name: m.Name,
                Dosage: m.Dosage,
                Form: m.Form,
                Code: m.Code,
                Unit: m.Unit,
                Description: m.Description,
                ExpiredAt: m.ExpiredAt,
                Stock: m.Stock,
                AlertStock: m.AlertStock,
                AvrgStock: m.AvrgStock,
                MinStock: m.MinStock,
                SafetyStock: m.SafetyStock,
                ReservedStock: m.ReservedStock,
                Price: m.Price
                                         )).ToList()
                        ));
        }
    }
}
