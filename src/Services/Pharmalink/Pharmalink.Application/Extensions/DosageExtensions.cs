namespace Pharmalink.Application.Extensions;

public static partial class DosageExtensions
{
    public static IEnumerable<DosageDto> ToDosageDto(this List<Dosage> dosages)
    {
        return dosages.Select(d => new DosageDto(
            Id: d.Id.Value,
            Code: d.Code,
            Label: d.Label
            ));
    }

}
