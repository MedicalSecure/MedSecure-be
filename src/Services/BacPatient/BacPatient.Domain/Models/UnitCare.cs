
namespace BacPatient.Domain.Models
{
    public class UnitCare : Aggregate<UnitCareId>
    {
        public string Title { get; private set; } = default!;
        public string Type { get; private set; } = default!;

        public string Description { get; private set; } = default!;
        public Status Status { get; private set; } = default!;

        public static UnitCare Create(
            UnitCareId Id ,
    string Title,
    string Type,
    string Description,
    Status Status
)
        {
            var unitCare = new UnitCare()
            {
                Id = Id ,
                Title = Title,
                Type = Type,
                Description = Description,
                Status = Status
            };

            return unitCare;
        }

    }
}
