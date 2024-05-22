namespace UnitCare.Domain.ValueObjects
{
    public record TaskId
    {
        public Guid Value { get; }

        private TaskId(Guid value) => Value = value;

        public static TaskId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("TaskId cannot be empty!");
            }
            return new TaskId(value);
        }
    }
}
