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
            var testId = TestId.Of(command.Test.Id);
            var test = await _dbContext.Tests.FindAsync([testId], cancellationToken);

            if (test == null)
            {
                throw new TestNotFoundException(command.Test.Id);
            }

            UpdateTest(test, command.Test);

            _dbContext.Tests.Update(test);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateTestResult(true);
        }

        private static void UpdateTest(Domain.Models.Test existingTest, TestDto newTestDto)
        {
            // Update the properties of the existing test with the data from the new DTO
            existingTest.Code = newTestDto.code;
            existingTest.Description = newTestDto.description;
            existingTest.Language = newTestDto.language;
            existingTest.Type = newTestDto.testType;
        }
    }
}
