namespace BacPatient.Domain.Models
{
    public class Comment : Entity<Guid>
    {
        public string Label { get; private set; }

        public string Content { get; private set; }

        public Guid PosologyId { get; private set; }
        public Posology? posology { get; private set; }

        private Comment()
        { } // Required for EF Core

        private Comment(Guid id, Guid posologyId, string label, string content)
        {
            Validator.isNotNullOrWhiteSpace(label, nameof(label));
            Validator.isNotNullOrWhiteSpace(content, nameof(content));

            Id = id;
            PosologyId = posologyId;
            Label = label;
            Content = content;
        }

        public static Comment Create(Guid posologyId, string label, string content)
        {
            return new Comment(new Guid(), posologyId, label, content);
        }
        public static Comment Create(Guid id, Guid posologyId, string label, string content)
        {
            return new Comment(id, posologyId, label, content);
        }
    }
}