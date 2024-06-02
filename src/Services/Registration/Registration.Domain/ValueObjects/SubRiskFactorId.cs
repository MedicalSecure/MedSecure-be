namespace Registration.Domain.ValueObjects
{
    public record SubRiskFactorId
    {
        public Guid Value { get; }

        // Public parameterless constructor
        public SubRiskFactorId() => Value = default;

        private SubRiskFactorId(Guid value) => Value = value;

        public static SubRiskFactorId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("SubRiskFactorId cannot be empty!");
            }
            return new SubRiskFactorId(value);
        }
    }
}
