namespace Diet.Application.Diets.Commands.CreateDiet;



public class CreateDietHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateDietCommand, CreateDietResult>
{
    public async Task<CreateDietResult> Handle(CreateDietCommand command, CancellationToken cancellationToken)
    {
        // create Diet entity from command object
        var diet = CreateNewDiet(command.Diet);

        // save to database
        dbContext.Diets.Add(diet);
        await dbContext.SaveChangesAsync(cancellationToken);

        // Check if the feature for using message broker is enabled
        if (await featureManager.IsEnabledAsync("DietPlanSharedFulfillment"))
        {
            // Adapt the command.Diet object to a DietPlanSharedEvent and publish it
            var eventMessage = command.Diet.Adapt<DietPlanSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }

        // return result containing the ID of the created diet
        return new CreateDietResult(diet.Id.Value);
    }

    private static Domain.Models.Diet CreateNewDiet(DietDto dietDto)
    {
        var newDiet = Domain.Models.Diet.Create(
            id: DietId.Of(Guid.NewGuid()),
            prescription: dietDto.Prescription.ToPrescriptionEntity(),
            startDate: dietDto.StartDate,
            endDate: dietDto.EndDate,
            dietType: dietDto.DietType,
            label : dietDto.Label
            );

        foreach (var meal in dietDto.Meals)
        {
            var newMeal = DailyMeal.Create(DailyMealId.Of(Guid.NewGuid()), meal.DietDate);
            newDiet.AddMeal(newMeal);
        }
    

        return newDiet;
    }
}