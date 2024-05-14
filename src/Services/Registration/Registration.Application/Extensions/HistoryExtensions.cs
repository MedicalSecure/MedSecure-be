
namespace Registration.Application.Extensions
{
    public static partial class HistoryExtensions
    {
        public static IEnumerable<HistoryDto> ToHistoryDto(this List<Domain.Models.History> histories)
        {
            return histories.Select(h => new HistoryDto(
                id: h.Id.Value,
                date: h.Date,
                status: h.Status,
                registerId: h.RegisterId.Value
            ));
        }
    }
}
