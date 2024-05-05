
namespace Visit.Domain.Models;

public class Visit : Aggregate<VisitId>
{
    public DateTime StartDate { get; set; } = default!; // Visit start date
    public DateTime EndDate { get; set; } = default!; // Visit end date
    public Patient Patient { get; private set; } = default!; // Patient ID
    public DoctorId DoctorId { get; private set; } = default!; // Doctor ID
    public string Title { get; private set; } = default!; // Visit title
    public TypeVisit TypeVisit { get; private set; } = default!; // Visit type
    public LocationVisit LocationVisit { get; private set; } = default!; // Visit location
    public string Duration { get; private set; } = default!; // Visit duration
    public string Description { get; private set; } = default!; // Visit description
    public string Availability { get; private set; } = default!; // Visit availability

    // Create a new visit
    public static Visit CreateVisit(VisitId id,
        DateTime startDate,
        DateTime endDate, 
        DoctorId doctorId ,
        Patient patient, 
        string title, 
        TypeVisit typeVisit,
        LocationVisit locationVisit, 
        string duration, 
        string description, 
        string availability)
    {
        var visit = new Visit()
        {
            Id = id,
            StartDate = startDate,
            EndDate = endDate,
            Patient = patient,
            DoctorId =doctorId,
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

    // Update visit details
    public void UpdateVisit(DateTime startDate, 
        DateTime endDate, 
        string title,
        DoctorId doctorId,
        Patient patient,
        TypeVisit typeVisit,
        LocationVisit locationVisit, 
        string duration,
        string description, 
        string availability)
    {
        StartDate = startDate;
        EndDate = endDate;
        Patient = patient;
        DoctorId = doctorId;
        Title = title;
        TypeVisit = typeVisit;
        LocationVisit = locationVisit;
        Duration = duration;
        Description = description;
        Availability = availability;

        AddDomainEvent(new VisitUpdtedEvent(this));
    }
}
