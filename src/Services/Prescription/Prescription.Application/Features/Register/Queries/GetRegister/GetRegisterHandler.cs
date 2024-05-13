namespace Prescription.Application.Features.Diagnosis.Queries.GetDiagnosis
{
    public class GetRegisterHandler(IApplicationDbContext dbContext) : IQueryHandler<GetRegisterQuery, GetRegisterResult>
    {
        public async Task<GetRegisterResult> Handle(GetRegisterQuery query, CancellationToken cancellationToken)
        {
            // get diagnosis with pagination
            // return result

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Register.LongCountAsync(cancellationToken);

            var riskFactor = await dbContext.RiskFactor.ToListAsync(cancellationToken);
            /*
                        var prescriptions = await dbContext.Prescriptions
                                      .Include(p => p.Symptoms)
                                      .Include(p => p.Diagnosis)
                                      .Include(p => p.Register)
                                      .Include(p => p.Posology)
                                      .ThenInclude(posology => posology.Comments)
                                      .Include(p => p.Posology)
                                      .ThenInclude(posology => posology.Dispenses)
                                      .Include(p => p.Posology)
                                      .ThenInclude(posology => posology.Medication)
                                      .OrderBy(o => o.CreatedAt)
                                      .Skip(pageSize * pageIndex)
                                      .Take(pageSize)
                                      .ToListAsync(cancellationToken);*/

            var registers = await dbContext.Register
                                .Include(r => r.Patient)
                                /*                                .Include(r => r.FamilyMedicalHistory)

                                                                .Include(r => r.PersonalMedicalHistory)

                                                                .Include(r => r.Diseases)

                                                                .Include(r => r.Allergies)

                                                                .Include(r => r.History)*/
                                .Include(r => r.Test)
                                .OrderBy(o => o.CreatedAt)
                                .Skip(pageSize * pageIndex)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);

            /*      var prescriptionsWithRegisters = prescriptions.Join(
                          registers,
                          prescription => prescription.RegisterId,
                          register => register.Id,
                          (prescription, register) => register.Prescriptions.Add(prescription))
                          .ToList();*/
            /*            var prescriptionsGroupedByRegister = prescriptions.GroupBy(p => p.RegisterId);

                        foreach (var register in registers)
                        {
                            register.AddPrescriptions(prescriptionsGroupedByRegister
                                .Where(g => g.Key == register.Id)
                                .SelectMany(g => g)
                                .ToList());
                        }*/
            var x = new GetRegisterResult(
                new PaginatedResult<RegisterDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    registers.ToRegisterDto()));

            return x;
        }
    }
}