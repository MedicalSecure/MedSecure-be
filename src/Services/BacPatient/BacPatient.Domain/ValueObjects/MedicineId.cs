
namespace BacPatient.Domain.ValueObjects
{
    public record  MedicineId
    {
        public Guid Value { get; }
        private MedicineId() { }

        private MedicineId(Guid value) => Value = value;

        public static MedicineId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("MedicineId cannot be empty!");
            }
            return new MedicineId(value);
        }
    }
}
