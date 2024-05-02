
namespace Registration.Application.Dtos
{
    public record HistoryDto(Guid Id,DateTime date, Status status, PatientId patientId);

}
