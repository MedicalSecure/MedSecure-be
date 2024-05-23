namespace Registration.Application.Extensions
{
    public static partial class HistoryExtensions
    {
        public static IEnumerable<HistoryDto> ToHistoryDto(this List<History> histories)
        {
            return histories.Select(h => h.ToHistoryDto());
        }

        public static HistoryDto ToHistoryDto(this History h)
        {
            return new HistoryDto(
                            id: h.Id.Value,
                            date: h.Date,
                            status: h.Status,
                            registerId: h.RegisterId.Value
                            );
        }
    }
}