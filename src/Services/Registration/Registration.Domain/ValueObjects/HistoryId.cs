/*
namespace Registration.Domain.ValueObjects
{
    public record HistoryId
    {
        public Guid Value { get; }

        private HistoryId(Guid value) => Value = value;

        public static HistoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("HistoryId cannot be empty!");
            }
            return new HistoryId(value);
        }
    }
}*/

namespace Registration.Domain.ValueObjects
{
    public record HistoryId
    {
        public Guid Value { get; }

        // Public parameterless constructor
        public HistoryId() => Value = default;

        private HistoryId(Guid value) => Value = value;

        public static HistoryId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("HistoryId cannot be empty!");
            }
            return new HistoryId(value);
        }
    }
}
