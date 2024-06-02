using Registration.Application.Tests.Commands.CreateTest;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Registers.Commands.CreateRegister
{
    public class CreateTestHandler : IRequestHandler<CreateTestCommand, CreateTestResult>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateTestHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateTestResult> Handle(CreateTestCommand command, CancellationToken cancellationToken)
        {
            if (command.Test.RegisterId == null || command.Test.RegisterId == Guid.Empty)
            {
                throw new ArgumentNullException("Register Id is required for creating a test");
            }
            var test = CreateNewTest(command.Test);

            _dbContext.Tests.Add(test);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateTestResult(test.Id.Value);
        }

        public static Test CreateNewTest(TestDto testDto, Guid? registerId = null)
        {
            Guid finalRegisterId = registerId ?? (testDto.RegisterId ?? Guid.Empty);
            var newTest = Test.Create(
                id: TestId.Of(Guid.NewGuid()),
                code: testDto.Code,
                description: testDto.Description,
                language: testDto.Language,
                type: testDto.TestType,
                registerId: RegisterId.Of(finalRegisterId) // will throw an error if Guid.Empty, but this line will no be reached, we will check above if the regiser id is null
            );

            return newTest;
        }
    }
}