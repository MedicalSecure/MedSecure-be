namespace Medication.Application.Extensions;

public static class ActivityExtension
{
    public static ICollection<ActivityDto> ToActivitiesDto(this IReadOnlyList<Domain.Models.Activity> Activities)
    {
        return Activities.Select(s => s.ToActivityDto()).ToList();
    }

    public static ActivityDto ToActivityDto(this Activity Activity)
    {
        return new ActivityDto(
            Id: Activity.Id,
            Content: Activity.Content,
            CreatedAt: Activity.CreatedAt,
            CreatedBy: Activity.CreatedBy,
            CreatorName: Activity.CreatorName
        );
    }
}