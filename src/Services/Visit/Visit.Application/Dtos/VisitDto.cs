

namespace Visit.Application.Dtos;

public record VisitDto (Guid Id , DateTime StartDate, DateTime EndDate, PatientId PatientId, DoctorId DoctorId, string Title, TypeVisit TypeVisit, LocationVisit LocationVisit, string Duration, string Description, string Availability);

