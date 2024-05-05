

namespace Registration.Domain.ValueObjects
{
    public  record PatientId
    {
        public Guid Value { get; }

        private PatientId(Guid value) => Value = value;

        public static PatientId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("AssociatedPatientId cannot be empty!");
            }
            return new PatientId(value);
        }
    }
}
