using Registration.Domain.Models;

namespace Registration.Application.Registers.Queries.GetRegistersById
{
    public class GetRegistersByIdHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetRegistersByIdQuery, GetRegistersByIdResult>
    {
        public async Task<GetRegistersByIdResult> Handle(GetRegistersByIdQuery query, CancellationToken cancellationToken)

        {
            // get patients with pagination
            // return result
            var regId = query.Id;

            if (regId == Guid.Empty)
                throw new ArgumentNullException($"Register Id {regId} is invalid");
            try
            {
                var registerId = RegisterId.Of(regId);

                var register = await dbContext.Registers
                    .Include(t => t.Patient)
                    .Include(t => t.Tests)
                    .Include(r => r.FamilyMedicalHistory)
                    .Include(r => r.PersonalMedicalHistory)
                    .Include(r => r.Disease)
                    .Include(r => r.Allergy)
                    .Include(t => t.History)
                    .FirstOrDefaultAsync(r => r.Id == registerId, cancellationToken);

                //Auto include the riskFactors
                var riskFactor = await dbContext.RiskFactors.ToListAsync(cancellationToken);


                if (register == null)
                    throw new ArgumentNullException(nameof(register) + $" with id {regId} is not found");
                var registersDto = register.Status == RegisterStatus.Archived ? register.ToRegisterDto(isArchived: true) : register.ToRegisterDto(isArchived: false);

                return new GetRegistersByIdResult(registersDto);
            }
            catch (Exception x)
            {
                throw new ArgumentNullException($"Register with id ${regId} is not found", x);
            }
        }
    }
}