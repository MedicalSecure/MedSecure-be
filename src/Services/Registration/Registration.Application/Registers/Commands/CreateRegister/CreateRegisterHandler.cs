using Registration.Application.Patients.Commands.CreatePatient;
using Registration.Application.Histories.Commands.CreateHistory;
using Registration.Application.RiskFactors.Commands.CreateRiskFactor;
using BuildingBlocks.Messaging.Events.RegistrationEvents;
using BuildingBlocks.Messaging.Events.RegistrationSharedEvents;

namespace Registration.Application.Registers.Commands.CreateRegister
{
    public class CreateRegisterHandler(IApplicationDbContext dbContext, IPublishEndpoint publisher) : ICommandHandler<CreateRegisterCommand, CreateRegisterResult>
    {
        public async Task<CreateRegisterResult> Handle(CreateRegisterCommand command, CancellationToken cancellationToken)
        {
            // create register entity from command object
            // save to database
            // return result
            var register = CreateNewRegister(command.register);

            dbContext.Registers.Add(register);
            await dbContext.SaveChangesAsync(cancellationToken);

            //prepare data for the event
            var registerToSend = await dbContext.Registers
                    .Include(t => t.Patient)
                    .Include(t => t.Tests)
                    .Include(r => r.FamilyMedicalHistory)
                    .Include(r => r.PersonalMedicalHistory)
                    .Include(r => r.Disease)
                    .Include(r => r.Allergy)
                    .Include(t => t.History)
                    .FirstOrDefaultAsync(r => r.Id == register.Id, cancellationToken);

            if (registerToSend != null)
            {
                //Auto include the riskFactors
                var riskFactor = await dbContext.RiskFactors.ToListAsync(cancellationToken);

                // map the data
                RegisterDto registerTomap = registerToSend.ToRegisterDto();
                RegisterSharedEvent registerSharedEvent = registerTomap.Adapt<RegisterSharedEvent>();
                var eventToSend = new NewRegisterSharedEvent(registerSharedEvent);
                await publisher.Publish(eventToSend);
            }

            return new CreateRegisterResult(register.Id.Value);
        }

        private static Register CreateNewRegister(RegisterDto registerDto)
        {
            if (registerDto == null)
            {
                throw new ArgumentNullException(nameof(registerDto), "RegisterDto cannot be null");
            }

            if (registerDto.Patient == null)
            {
                throw new ArgumentNullException(nameof(registerDto.Patient), "PatientDto cannot be null");
            }

            var newRegisterId = RegisterId.Of(Guid.NewGuid());
            IEnumerable<RiskFactor>? familyHistory = registerDto.FamilyMedicalHistory?.Select(h => CreateRiskFactorHandler.CreateNewRiskFactor(h, null));
            IEnumerable<RiskFactor>? personalHistory = registerDto.PersonalMedicalHistory?.Select(h => CreateRiskFactorHandler.CreateNewRiskFactor(h, null));
            IEnumerable<RiskFactor>? diseases = registerDto.Diseases?.Select(h => CreateRiskFactorHandler.CreateNewRiskFactor(h, null));
            IEnumerable<RiskFactor>? allergies = registerDto.Allergies?.Select(h => CreateRiskFactorHandler.CreateNewRiskFactor(h, null));

            IEnumerable<Test>? testList = registerDto.Test?.Select(t => CreateTestHandler.CreateNewTest(t, newRegisterId.Value));

            var register = Register.Create(
               id: newRegisterId,
               patient: CreatePatientHandler.CreateNewPatient(registerDto.Patient),
               familyHistory: familyHistory,
               personalHistory: personalHistory,
               diseases: diseases,
               allergies: allergies,
               testList: testList
           );

            // Accessing properties with null checks and providing default values if they are null

            return register;
        }
    }
}