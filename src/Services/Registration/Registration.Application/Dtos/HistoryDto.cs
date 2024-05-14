namespace Registration.Application.Dtos
{
    public record HistoryDto
    {
        public Guid Id { get; init; }
        public DateTime? Date { get; init; }
        public Status? Status { get; init; }
        public Guid RegisterId { get; init; }

        public HistoryDto(Guid id, DateTime? date, Status? status, Guid registerId)
        {
            Id = id;
            Date = date;
            Status = status;
            RegisterId = registerId;
        }
    }
}
