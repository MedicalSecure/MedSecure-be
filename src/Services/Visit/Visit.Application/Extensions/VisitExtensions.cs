

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
                          Patient: new PatientDto(
                              Id: d.Id.Value,
                              FirstName: d.Patient.FirstName,
                              LastName: d.Patient.LastName,
                              DateOfBirth: d.Patient.DateOfBirth,
                              CIN: d.Patient.CIN,
                              CNAM: d.Patient.CNAM,
                              Gender: d.Patient.Gender,
                              Height: d.Patient.Height,
                              Weight: d.Patient.Weight,
                              AddressIsRegisterations:d.Patient.AddressIsRegisterations,
                              SaveForNextTime:d.Patient.SaveForNextTime,
                              Email: d.Patient.Email,
                              Address1: d.Patient.Address1,
                              Address2: d.Patient.Address2,
                              ActivityStatus :d.Patient.ActivityStatus,
                              Country: d.Patient.Country,
                              State: d.Patient.State,
                              ZipCode:d.Patient.ZipCode,
                              FamilyStatus: d.Patient.FamilyStatus,
                              Children: d.Patient.Children
                          ),
                          DoctorId: d.DoctorId.Value,
                          Title: d.Title,
                          TypeVisit: d.TypeVisit,
                          LocationVisit: d.LocationVisit,
                          Duration: d.Duration,
                          Description: d.Description,
                          Availability: d.Availability

                      ));
    }
}
