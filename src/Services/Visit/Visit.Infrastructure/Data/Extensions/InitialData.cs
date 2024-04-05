using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Infrastructure.Data.Extensions;

internal class InitialData
{
    private static readonly string patientId = "5485125-chddf-565d-b35c-4853247ff10";
    private static readonly string doctorId = "458888-6584-565d-b35c-859995fff";

    public static IEnumerable<Domain.Models.Visit> Visits
    {
        get
        {
            try
            {
                {
                    // Créer des instances de visite
                    var visit = Domain.Models.Visit.CreateVisit(
                          id: VisitId.Of(Guid.NewGuid()),
                          startDate: DateTime.Now,
                          endDate: DateTime.Now.AddHours(1),
                          patientId: new List<PatientId> { PatientId.Of(new Guid(patientId)) },
                          doctorId: DoctorId.Of(new Guid(doctorId)),
                          title: "Visite de suivi",
                          typeVisit: TypeVisit.FollowUp,
                          locationVisit: LocationVisit.InClinic,
                          duration: "60 min",
                          description: "Description de la visite de suivi",
                          availability: "10:00");

                    return new List<Domain.Models.Visit> { visit };
                };
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Visit), ex.Message);
            }
        }
    }

}
