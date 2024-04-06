using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Infrastructure.Data.Extensions;

internal class InitialData
{
    private static readonly string patientId = "7506213d-3b5f-4498-b35c-9169a600ff10";
    private static readonly string doctorId = "7506213d-3b5f-4498-b35c-9169a600ff10";



    public static IEnumerable<Patient> Patients
    {
        get
        {
            try
            {
                return new List<Patient>
                    {
                        // Create Patient instances
                        Patient.Create(
                            id: PatientId.Of(new Guid(patientId)),
                            firstName: "Joury",
                            lastName: "JJ",
                            dateOfBirth: new DateTime(2002, 02, 22),
                            gender: Gender.Female),
                    };
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Patient), ex.Message);
            }
        }
    }

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
                          patientId:PatientId.Of(new Guid(patientId)) ,
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
                throw new EntityCreationException(nameof(Domain.Models.Visit), ex.Message);
            }
        }
    }

}
