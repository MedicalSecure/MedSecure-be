namespace Diet.Application.Diets.Commands.CreateDiet;

public class CreateDietHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateDietCommand, CreateDietResult>
{
    public async Task<CreateDietResult> Handle(CreateDietCommand command, CancellationToken cancellationToken)
    {
        // create Diet entity from command object
        // save to database
        // return result
        var diet = CreateNewDiet(command.Diet);

        dbContext.Diets.Add(diet);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateDietResult(diet.Id.Value);
    }

    private static Domain.Models.Diet CreateNewDiet(DietDto dietDto)
    {
        var newDiet = Domain.Models.Diet.Create(
            id: DietId.Of(Guid.NewGuid()),
            patientId: PatientId.Of(dietDto.PatientId),
            startDate: dietDto.StartDate,
            endDate: dietDto.EndDate,
            dietType: dietDto.DietType
            );

        foreach (var meal in dietDto.Meals)
        {
            var newMeal = Meal.Create(MealId.Of(meal.Id), DietId.Of(meal.DietId), meal.Name, meal.MealType);
            newDiet.AddMeal(newMeal);
        }

        return newDiet;
    }
}