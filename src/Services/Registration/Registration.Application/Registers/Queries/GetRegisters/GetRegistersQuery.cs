
namespace Registration.Application.Registers.Queries.GetRegisters
{
    public record GetRegistersQuery(PaginationRequest PaginationRequest) : IQuery<GetRegistersResult>;
    public record GetRegistersResult(PaginatedResult<RegisterDto> Registers);
}
