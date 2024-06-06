namespace Medication.Domain.Models;

public class Comment : Entity<CommentId>
{
    public string Label { get; private set; } = string.Empty;

    public string Content { get; private set; } = string.Empty;

    public PosologyId PosologyId { get; private set; } = default!;
    public Posology? Posology { get; private set; }

    private Comment()
    { } // Required for EF Core

    private Comment(CommentId id, PosologyId posologyId, string label, string content, string createdBy, DateTime createdAt, Posology? posology)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        Id = id;
        PosologyId = posologyId;
        Posology = posology;
        Label = label;
        Content = content;
    }

    public static Comment Create(PosologyId posologyId, string label, string content, string createdBy, DateTime createdAt = default, Posology? posology = null)
    {
        var CreatedAt = createdAt == default ? DateTime.Now : createdAt;

        return new Comment(CommentId.Of(Guid.NewGuid()), posologyId, label, content, createdBy, CreatedAt, posology);
    }

    public static Comment Create(CommentId id, PosologyId posologyId, string label, string content, string createdBy, DateTime createdAt = default, Posology? posology = null)
    {
        var CreatedAt = createdAt == default ? DateTime.Now : createdAt;

        return new Comment(id, posologyId, label, content, createdBy, CreatedAt, posology);
    }
}