namespace BacPatient.Application.DTOs
{
    public abstract record EntityDto(
        Guid Id, DateTime? CreatedAt,
        string? CreatedBy,
        DateTime? LastModified,
        string? LastModifiedBy
        );
}