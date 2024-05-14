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
            var test = CreateNewTest(command.Test);

            _dbContext.Tests.Add(test);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CreateTestResult(test.Id.Value);
        }

        private static Test CreateNewTest(TestDto testDto)
        {
            var newTest = Test.Create(
                id:TestId.Of(Guid.NewGuid()),
                code: testDto.Code,
                description: testDto.Description,
                language: testDto.Language,
                type: testDto.TestType,
                registerId: RegisterId.Of(testDto.RegisterId)
            );

            return newTest;
        }
    }
}
