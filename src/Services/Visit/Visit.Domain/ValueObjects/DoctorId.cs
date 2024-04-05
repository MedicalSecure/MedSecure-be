

namespace Visit.Domain.ValueObjects
{
  public record DoctorId
    {
        public Guid Value { get; }
        private DoctorId(Guid value) => Value = value;

        public static DoctorId Of (Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException ("DoctorId cannot be empty!");
            }
            return new DoctorId(value);
        }
    }
}
