namespace Prescription.Domain.Entities
{
    public class Comment : Entity<CommentId>
    {
        public string Label { get; private set; } = string.Empty;

        public string Content { get; private set; } = string.Empty;

        public PosologyId PosologyId { get; private set; } = default!;
        public Posology? posology { get; private set; }

        private Comment()
        { } // Required for EF Core

        private Comment(CommentId id, PosologyId posologyId, string label, string content, string createdBy, DateTime createdAt)
        {
            Validator.isNotNullOrWhiteSpace(label, nameof(label));
            Validator.isNotNullOrWhiteSpace(content, nameof(content));
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            Id = id;
            PosologyId = posologyId;
            Label = label;
            Content = content;
        }

        public static Comment Create(PosologyId posologyId, string label, string content, string createdBy, DateTime createdAt = default)
        {
            var CreatedAt = createdAt == default ? DateTime.Now : createdAt;

            return new Comment(CommentId.Of(Guid.NewGuid()), posologyId, label, content, createdBy, CreatedAt);
        }

        public static Comment Create(CommentId id, PosologyId posologyId, string label, string content, string createdBy, DateTime createdAt = default)
        {
            var CreatedAt = createdAt == default ? DateTime.Now : createdAt;

            return new Comment(id, posologyId, label, content, createdBy, CreatedAt);
        }
    }
}