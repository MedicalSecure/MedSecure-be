namespace BacPatient.Domain.Models.RegisterRoot
{
    public class Test : Aggregate<TestId>
    {
        // Properties
        public string? Code { get; private set; } = default!;
        public string? Description { get; private set; } = default!;
        public Language? Language { get; private set; } = default!;
        public TestType? Type { get; private set; } = default!;
        public RegisterId RegisterId { get; private set; } = default!;

        // Constructor (private to enforce creation through factory method)
        public Test() { }

        // Factory method
        public static Test Create(TestId id, string? code, string? description, Language? language, TestType? type, RegisterId registerId)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Code cannot be null or empty.", nameof(code));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            var test = new Test
            {
                Id = id,
                Code = code,
                Description = description,
                Language = language,
                Type = type,
                RegisterId = registerId
            };
            return test;
        }

        // Method to update the test
        public void Update(TestId id, string code, string description, Language language, TestType type, RegisterId registerId)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Code cannot be null or empty.", nameof(code));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            Id = id;
            Code = code;
            Description = description;
            Language = language;
            Type = type;
            RegisterId = registerId;
        }
    }
}