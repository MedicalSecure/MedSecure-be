namespace BacPatient.Domain.Models.RegisterRoot
{
    public class Test : Entity<TestId>
    {
        public string Code { get; private set; }
        public string Description { get; private set; }
        public Language Language { get; private set; }
        public TestType Type { get; private set; }
        public Guid RegisterId { get; private set; }

        private Test()
        { } // Required by EF Core for entity types

        private Test(TestId id, Guid registerId, string code, string description, Language language, TestType type)
        {
            Id = id;
            Code = code;
            Description = description;
            Language = language;
            Type = type;
            RegisterId = registerId;
        }

        public static Test Create(Guid registerId, string code, string description, Language language, TestType type)
        {
            return new Test(TestId.Of(Guid.NewGuid()), registerId, code, description, language, type);
        }

        public static Test Create(TestId id, Guid registerId, string code, string description, Language language, TestType type)
        {
            return new Test(id, registerId, code, description, language, type);
        }
    }
}