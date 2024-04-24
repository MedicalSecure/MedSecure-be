namespace BacPatient.Application.Extensions
{
    public static partial class UnitCareExtensions
    {
        public static IEnumerable<UnitCareDto> ToUnitCareDtos(this IEnumerable<UnitCare> unitCares)
        {
            return unitCares.Select(d => new UnitCareDto(
                            Id: d.Id.Value,
                            Title:d.Title,
                            Type:d.Type,
                            Description:d.Description,
                            Status:d.Status
                ));

        }
    }
}
