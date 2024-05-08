namespace Prescription.Domain.Entities.RegisterRoot
{
    public class Test : Entity<TestId>
    {
        public string Code { get; private set; }
        public string Description { get; private set; }
        public Language Language { get; private set; }
        public TestType Type { get; private set; }
        public RegisterId RegisterId { get; private set; }

        public Test()
        { }

        private Test(TestId id, RegisterId registerId, string code, string description, Language language, TestType type)
        {
            Id = id;
            Code = code;
            Description = description;
            Language = language;
            Type = type;
            RegisterId = registerId;
        }

        public static Test Create(RegisterId registerId, string code, string description, Language language, TestType type)
        {
            return new Test(TestId.Of(Guid.NewGuid()), registerId, code, description, language, type);
        }

        public static Test Create(TestId id, RegisterId registerId, string code, string description, Language language, TestType type)
        {
            return new Test(id, registerId, code, description, language, type);
        }
    }
}