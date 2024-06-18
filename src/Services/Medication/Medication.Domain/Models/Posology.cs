namespace Medication.Domain.Models;

public class Posology : Aggregate<PosologyId>
{
    private readonly List<Comment> _comments = new();
    private readonly List<Dispense> _dispenses = new();

    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
    public IReadOnlyCollection<Dispense> Dispenses => _dispenses.AsReadOnly();

    public DrugId DrugId { get; private set; }

    public Drug? Drug { get; private set; }

    public ValidationId ValidationId { get; private set; }
    public Validation? Validation { get; private set; }

    private Posology()
    {
    }

    public void AddComment(string content, string label = "Note", string createdBy = "Hammadi pharmacist", DateTime createdAt = default)
    {
        if (content.Length == 0) { return; }
        var comm = Comment.Create(this.Id, label, content, createdBy, createdAt);
        _comments.Add(comm);
    }

    public void AddComment(Comment c)
    {
        _comments.Add(c);
    }

    public void AddDispense(Dispense dispense)
    {
        _dispenses.Add(dispense);
    }

    // New method for creating a PosologySummary for an existing Drug
    public static Posology Create(ValidationId validationId, DrugId drugId)
    {
        return new Posology()
        {
            ValidationId = validationId,
            DrugId = drugId,
            Id = PosologyId.Of(Guid.NewGuid()),
        };
    }
}