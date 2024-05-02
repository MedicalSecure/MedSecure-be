
namespace BacPatient.Domain.ValueObjects
{
    public class TestId
    {
        public Guid Value { get; }

        private TestId(Guid value) => Value = value;

        public static TestId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("TestId cannot be empty!");
            }
            return new TestId(value);
        }
    }
}

