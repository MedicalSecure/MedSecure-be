namespace Medication.Domain.Models;

public class Activity
{
    public Guid Id { get; init; }
    public string Content { get; init; }
    public Guid CreatedBy { get; init; }
    public string CreatorName { get; init; }

    public DateTime CreatedAt { get; init; }

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
