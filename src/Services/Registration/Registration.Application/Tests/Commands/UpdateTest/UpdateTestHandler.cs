namespace Registration.Application.Tests.Commands.UpdateTest
{
    public class UpdateTestHandler : ICommandHandler<UpdateTestCommand, UpdateTestResult>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateTestHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UpdateTestResult> Handle(UpdateTestCommand command, CancellationToken cancellationToken)
        {
            if (command.Test == null || command.Test?.Id == null)
            {
                throw new ArgumentNullException("Test id is required for updates");
            }

            var testId = TestId.Of(command.Test.Id ?? Guid.NewGuid());
            var test = await _dbContext.Tests.FindAsync([testId], cancellationToken);

            if (test == null)
            {
                throw new TestNotFoundException(testId.Value);
            }

            UpdateTest(test, command.Test);

            _dbContext.Tests.Update(test);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateTestResult(true);
        }

        private static void UpdateTest(Domain.Models.Test existingTest, TestDto newTestDto)
        {
            // existingTest.Update( .. );
            // to do
        }
    }
}