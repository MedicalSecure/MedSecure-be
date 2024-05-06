using BacPatient.Application.Extensions.SimpleBacPatientExtension;
using System.Linq;

namespace BacPatient.Application.Extensions
{
    public static partial class PatientExtensions
    {
        public static IEnumerable<BacPatientDto> ToBacPatientDtos(this IEnumerable<Domain.Models.BacPatient> bacPatients)
        {
            return bacPatients.Select(d => new BacPatientDto(
                Id : d.Id,
                Prescription: d.Prescription.ToSimplePrescriptionDto(),
                Bed : d.Bed ,
                NurseId : d.NurseId , 
                Served : d.Served ,
                ToServe : d.ToServe , 
                Status : d.Status 
                ));
          
        }
    }
}
