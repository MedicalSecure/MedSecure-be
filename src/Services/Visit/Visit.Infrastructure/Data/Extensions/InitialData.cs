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


    public static IEnumerable<Domain.Models.Visit> Visits
    {
        get
        {
            try
            {
                {
                    //creer des instance patient
                    var patient = Patient.Create(
                       id: PatientId.Of(new Guid(patientId)),
                       firstName: "Joury",
                       lastName: "Jamel",
                       dateOfbirth: new DateTime(2002, 02, 22),
                       cin: 12345, // Your desired values for CIN and CNAM
                       cnam: 67890,
                       gender: Gender.Female,
                       height: 170, // Sample height and weight
                       weight: 60,
                       email: "joury@example.com",
                       address1: "Address Line 1",
                       address2: "Address Line 2",
                       country: Country.US, // Sample country
                       state: "Sample State",
                       familyStatus: FamilyStatus.MARRIED, // Sample family status
                       children: Children.None // Sample children status
                   );
                    // Créer des instances de visite
                    var visit = Domain.Models.Visit.CreateVisit(
                          id: VisitId.Of(Guid.NewGuid()),
                          startDate: DateTime.Now,
                          endDate: DateTime.Now.AddHours(1),
                          patient: patient,
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
