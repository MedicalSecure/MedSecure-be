
using Visit.Domain.Events;

namespace Visit.Domain.Models;

public class Visit : Aggregate<VisitId>
{
    public DateTime StartDate { get; set; }=default!; // Date de début de la visite
    public DateTime EndDate { get; set; } = default!; // Date de fin de la visite
    public PatientId PatientId { get; private set; } = default!; // Liste des ID des patients
    public DoctorId DoctorId { get; private set; } = default!; // ID du médecin
    public string Title { get; private set; } = default!;  // Titre de la visite
    public TypeVisit TypeVisit { get; private set; } = default!; // Type de visite
    public LocationVisit LocationVisit { get; private set; } = default!; // Lieu de la visite
    public string Duration { get; private set; } = default!;  // Durée de la visite
    public string Description { get; private set; } = default!; // Description de la visite
    public string Availability { get; private set; } = default!; // Disponibilité de la visite

    // create new visit
    public static Visit CreateVisit(VisitId id ,DateTime startDate, DateTime endDate, PatientId patientId, DoctorId doctorId, string title, TypeVisit typeVisit, LocationVisit locationVisit, string duration, string description, string availability)
        {

        var visit = new Visit ()
        {
            Id = id,
            StartDate = startDate,
            EndDate = endDate,
            PatientId = patientId,
            DoctorId = doctorId,
            Title = title,
            TypeVisit = typeVisit,
            LocationVisit = locationVisit,
            Duration = duration,
            Description = description,
            Availability = availability
        };
        visit.AddDomainEvent(new VisitCreatedEvent(visit));
        return visit;

    }
    // updated visit
    public void  UpdateVisit(DateTime startDate, DateTime endDate, PatientId patientId, string title, TypeVisit typeVisit, LocationVisit locationVisit, string duration, string description, string availability)
    {


        StartDate = startDate;
        EndDate = endDate;
        PatientId = patientId;
        Title = title;
        TypeVisit = typeVisit;
        LocationVisit = locationVisit;
        Duration = duration;
        Description = description;
        Availability = availability;
        
       AddDomainEvent(new VisitUpdtedEvent(this));
     

    }
}
