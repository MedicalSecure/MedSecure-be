namespace Registration.Domain.Models
{
    public class Test : Aggregate<TestId>
    {
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Language Language { get; set; } = default!;
        public TestType Type { get; set; } = default!;

        public static Test Create(string code, string description, Language language, TestType type)
        {
            var test = new Test
            {
                Code = code,
                Description = description,
                Language = language,
                Type = type
            };
            return test;
        }

        public void Update(string code, string description, Language language, TestType type)
        {
            Code = code;
            Description = description;
            Language = language;
            Type = type;
        }
    }
}
