
//namespace Visit.Application.Doctors.Queries.GetDoctorDetail;

//public class GetDoctorDetailHandler(IApplicationDbContext dbContext) : IQueryHandler<GetDoctorDetailQuery, GetDoctorDetailResult>
//{
//    public async Task<GetDoctorDetailResult> Handle(GetDoctorDetailQuery query, CancellationToken cancellationToken)
//    {
//        // get doctors by Id using dbContext
//        // return result

//        var doctors = await dbContext.Doctors
//             .AsNoTracking()
//             .Where(o => o.FirstName.Contains(query.name) || o.LastName.Contains(query.name))
//             .OrderBy(o => o.DateOfBirth)
//             .ToListAsync(cancellationToken);

//        return new GetDoctorDetailResult(doctors.ToDoctortDto());
//    }
//}