using Diet.Domain.Shared;

namespace Diet.Domain.Models
{
    public class Comment : Entity<CommentId>
    {
        public string Label { get; private set; }

        public string Content { get; private set; }

        public PosologyId? PosologyId { get; private set; }
        public Posology? posology { get; private set; }
        public MealId? MealId { get; private set; }
        private Comment()
        { } // Required for EF Core
        public Comment( CommentId id , string label  , string content )
        {
            Id = id;
        Label = label ;
            Content = content ;
        }
        private Comment(CommentId id,PosologyId posologyId, string label, string content)
        {
            Validator.isNotNullOrWhiteSpace(label, nameof(label));
            Validator.isNotNullOrWhiteSpace(content, nameof(content));
            
            Id = id;
            PosologyId = posologyId;
            Label = label;
            Content = content;
        }

        public static Comment Create(PosologyId? posologyId, string label, string content)
        {
            return new Comment(CommentId.Of(Guid.NewGuid()),posologyId, label, content);
        }
        public static Comment Create(CommentId id , string label, string content)
        {
            return new Comment(id, label, content);
        }
        public static Comment Create(CommentId id,PosologyId? posologyId, string label, string content)
        {
            return new Comment(id,posologyId, label, content);
        }
    }
}