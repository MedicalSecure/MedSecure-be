using System.Linq;

namespace BacPatient.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<BacPatientDto> ToBacPatientDtos(this IEnumerable<Domain.Models.BacPatient> bacPatients)
        {
            return bacPatients.Select(d => new BacPatientDto(
                Id : d.Id,
                Prescription : d.Prescription.ToPrescriptionDto(),
                Room :new RoomDto (
                    d.Room.Id ,
                    d.Room.Number ,
                    d.Room.Status ,
                    d.Room.Beds
                    ),
                Bed : d.Bed ,
                NurseId : d.NurseId , 
                Served : d.Served ,
                ToServe : d.ToServe , 
                Status : d.Status   ));
          
        }
    }
}
