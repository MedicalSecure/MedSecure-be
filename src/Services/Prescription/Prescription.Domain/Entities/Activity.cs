namespace Prescription.Domain.Entities
{
    public class Activity
    {
        public Guid Id { get; init; } = default;
        public string Content { get; init; } = string.Empty;
        public Guid CreatedBy { get; init; } = default;
        public string CreatorName { get; init; } = string.Empty;

        public DateTime CreatedAt { get; init; } = default;

        public Activity()
        {
        } // For EF and Mapster

        private Activity(Guid createdBy, string content, string creatorName)
        {
            Id = Guid.NewGuid();
            Content = content;
            CreatedBy = createdBy;
            CreatorName = creatorName;
            CreatedAt = DateTime.Now;
        }

        public static Activity Create(Guid createdBy, string content, string creatorName)
        {
            return new Activity(createdBy, content, creatorName);
        }
    }
}