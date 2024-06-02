


namespace Visit.Application.Extensions;

public static class PatientExtension
{
    public static PatientDto? ToPatientDto(this Patient? d)
    {
        if (d == null) return null;
        return new PatientDto(
            Id: d.Id.Value,
            FirstName: d.FirstName,
            LastName: d.LastName,
            DateOfBirth: d.DateOfBirth,
            CIN: d.CIN,
            CNAM: d.CNAM,
            Gender: d.Gender,
            Height: d.Height,
            Weight: d.Weight,
            AddressIsRegisterations: d.AddressIsRegisterations,
            SaveForNextTime: d.SaveForNextTime,
            Email: d.Email,
            Address1: d.Address1,
            Address2: d.Address2,
            ActivityStatus: d.ActivityStatus,
            Country: d.Country,
            State: d.State,
            ZipCode: d.ZipCode,
            FamilyStatus: d.FamilyStatus,
            Children: d.Children
        );
    }

    public static ICollection<PatientDto> ToPatientDto(this IReadOnlyList<Patient?> patients)
    {
        if (patients == null)
            return new List<PatientDto>();

        return patients.Where(p => p != null)
                       .Select(p => p.ToPatientDto())
                       .Where(dto => dto != null)
                       .ToList();
    }
}