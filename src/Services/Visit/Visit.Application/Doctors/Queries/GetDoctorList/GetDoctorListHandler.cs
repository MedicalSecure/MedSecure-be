

//namespace Visit.Application.Doctors.Queries.GetDoctorList;
//    public class GetDoctorListHandler(IApplicationDbContext dbContext): IQueryHandler<GetDoctorListQuery, GetDoctorsResult>
//{
//    public async Task<GetDoctorsResult> Handle(GetDoctorListQuery query, CancellationToken cancellationToken)
//    {
//        // get doctors with pagination
//        // return result

//        var pageIndex = query.PaginationRequest.PageIndex;
//        var pageSize = query.PaginationRequest.PageSize;

//        var totalCount = await dbContext.Doctors.LongCountAsync(cancellationToken);

//        var doctors = await dbContext.Doctors
//                       .OrderBy(o => o.DateOfBirth)
//                       .Skip(pageSize * pageIndex)
//                       .Take(pageSize)
//                       .ToListAsync(cancellationToken);

//        return new GetDoctorsResult(
//            new PaginatedResult<DoctorDto>(
//                pageIndex,
//                pageSize,
//                totalCount,
//                doctors.ToDoctortDto()));
//    }
//}
