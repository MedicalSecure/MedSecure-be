namespace Medication.Application.Dtos;

public record ActivityDto(
       Guid Id,
       string Content,
       Guid CreatedBy,
       string CreatorName,
       DateTime CreatedAt
   );
