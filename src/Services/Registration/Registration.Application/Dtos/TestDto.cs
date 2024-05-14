namespace Registration.Application.Dtos
{
    public record TestDto
    {
        public Guid Id { get; init; }
        public string? Code { get; init; }
        public string? Description { get; init; }
        public Language? Language { get; init; }
        public TestType? TestType { get; init; }
        public Guid RegisterId { get; init; }

        public TestDto(Guid id, string? code, string? description, Language? language, TestType? testType, Guid registerId)
        {
            Id = id;
            Code = code;
            Description = description;
            Language = language;
            TestType = testType;
            RegisterId = registerId;
        }
    }
}
