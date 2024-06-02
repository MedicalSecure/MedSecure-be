namespace Registration.Application.Dtos
{
    public record HistoryDto
    {
        public Guid? Id { get; init; }
        public DateTime? Date { get; init; }
        public HistoryStatus Status { get; init; }
        public Guid RegisterId { get; init; }

        public HistoryDto(HistoryStatus status, Guid registerId, Guid? id, DateTime? date)
        {
            Id = id;
            Date = date;
            Status = status;
            RegisterId = registerId;
        }
    }
}