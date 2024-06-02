namespace Prescription.Domain.ValueObjects
{
    public record PersonnelId
    {
        public Guid Value { get; }

        private PersonnelId(Guid value) => Value = value;

        public static PersonnelId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException(" PersonnelId cannot be empty!");
            }
            return new PersonnelId(value);
        }
    }
}