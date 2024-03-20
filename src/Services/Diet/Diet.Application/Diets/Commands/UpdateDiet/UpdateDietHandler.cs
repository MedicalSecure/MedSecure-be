namespace Diet.Application.Diets.Commands.UpdateDiet;

public class UpdateDietHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateDietCommand, UpdateDietResult>
{
    public async Task<UpdateDietResult> Handle(UpdateDietCommand command, CancellationToken cancellationToken)
    {
        // Update Diet entity from command object
        // save to database
        // return result
        var dietId = DietId.Of(command.Diet.Id);
        var diet = await dbContext.Diets.FindAsync([dietId], cancellationToken);

        if (diet == null)
        {
            throw new DietNotFoundException(command.Diet.Id);
        }

        UpdateDietWithNewValues(diet, command.Diet);

        dbContext.Diets.Update(diet);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateDietResult(true);
    }

    private static void UpdateDietWithNewValues(Domain.Models.Diet diet, DietDto dietDto)
    {
        diet.Update(PatientId.Of(dietDto.PatientId), dietDto.StartDate, dietDto.EndDate, dietDto.DietType);
    }
}