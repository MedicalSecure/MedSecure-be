using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using Registration.Application.Dtos;


namespace Registration.Application.Register.Queries.GetRegisters
{
    public record GetRegistersQuery(PaginationRequest PaginationRequest) : IQuery<GetRegistersResult>;
    public record GetRegistersResult(PaginatedResult<RegisterDto> Registers);
}
