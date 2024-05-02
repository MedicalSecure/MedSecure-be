namespace BacPatient.Application.Dtos
{
    public abstract record EntityDto(
        Guid Id, DateTime? CreatedAt,
        string? CreatedBy,
        DateTime? LastModified,
        string? LastModifiedBy
        );
}