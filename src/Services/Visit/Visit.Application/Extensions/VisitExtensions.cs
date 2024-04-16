

namespace Visit.Application.Extensions;

public static partial class VisitExtensions
{
    public static IEnumerable<VisitDto> ToVisitDto(this List<Domain.Models.Visit> visits)
    {
        return visits.OrderBy(d => d.TypeVisit)
                      .Select(d => new VisitDto(
                          Id: d.Id.Value,
                          StartDate: d.StartDate,
                          EndDate: d.EndDate,
                          PatientId : d.PatientId.Value,
                          DoctorId : d.DoctorId.Value,
                          Title : d.Title,
                          TypeVisit : d.TypeVisit,
                          LocationVisit : d.LocationVisit,
                          Duration : d.Duration,
                          Description : d.Description,
                          Availability : d.Availability
            
                      ));
    }
}
