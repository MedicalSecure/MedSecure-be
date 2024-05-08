namespace Prescription.Domain.ValueObjects
{
    public record UnitCareId
    {
        public Guid Value { get; }

        private UnitCareId(Guid value) => Value = value;

        public static UnitCareId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UnitCareId cannot be empty!");
            }
            return new UnitCareId(value);
        }
        public static UnitCareId? OfNullable(Guid? value)
        {
            if (!value.HasValue)
            {
                return null;
            }

            if (value.Value == Guid.Empty)
            {
                throw new DomainException("UnitCareId cannot be empty!");
            }

            return new UnitCareId(value.Value);
        }
    }
}