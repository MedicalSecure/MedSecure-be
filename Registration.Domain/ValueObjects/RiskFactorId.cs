
namespace Registration.Domain.ValueObjects
{
    public record RiskFactorId
    {
        public Guid Value { get; }

        private RiskFactorId(Guid value) => Value = value;

        public static RiskFactorId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RiskFactorId cannot be empty!");
            }
            return new RiskFactorId(value);
        }
    }
}
