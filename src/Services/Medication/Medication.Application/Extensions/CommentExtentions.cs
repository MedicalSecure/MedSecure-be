namespace Medication.Application.Extensions;

public static class CommentExtension
{
    public static ICollection<CommentDto> ToCommentsDto(this IReadOnlyCollection<Domain.Models.Comment> Comments)
    {
        return Comments.Select(s => s.ToCommentDto()).ToList();
    }

    public static CommentDto ToCommentDto(this Comment Comment)
    {
        return new CommentDto(
            Id: Comment.Id.Value,
            PosologyId: Comment.PosologyId.Value,
            Label: Comment.Label,
            Content: Comment.Content,
            CreatedBy: Comment.CreatedBy ?? "Hammadi doctor",
            CreatedAt: Comment.CreatedAt ?? DateTime.Now
        );
    }
}