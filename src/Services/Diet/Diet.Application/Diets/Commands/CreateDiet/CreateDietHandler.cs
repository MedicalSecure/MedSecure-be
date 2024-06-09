using Diet.Application.Dtos;

namespace Diet.Application.Diets.Commands.CreateDiet;



public class CreateDietHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<CreateDietCommand, CreateDietResult>
{
    public async Task<CreateDietResult> Handle(CreateDietCommand command, CancellationToken cancellationToken)
    {
        var diet = CreateNewDiet(command.Diet);
        dbContext.Diets.Add(diet);
        await dbContext.SaveChangesAsync(cancellationToken);

        if (await featureManager.IsEnabledAsync("DietPlanSharedFulfillment"))
        {
            var eventMessage = command.Diet.Adapt<DietPlanSharedEvent>();
            await publishEndpoint.Publish(eventMessage, cancellationToken);
        }
        return new CreateDietResult(diet.Id.Value);
    }

    private static Domain.Models.Diet CreateNewDiet(DietDto dietDto)
    {
        var newDiet = Domain.Models.Diet.Create(
            id: DietId.Of(Guid.NewGuid()),
            register: dietDto.Register.ToRegisterEntity(),
            startDate: dietDto.StartDate,
            endDate: dietDto.EndDate,
            dietType: dietDto.DietType,
            label : dietDto.Label
            );

        foreach (var meal in dietDto.Meals)
        {
            var newMeal = Meal.Create(MealId.Of(Guid.NewGuid()), meal.Name , meal.MealType );
            foreach (var food in meal.Foods)
            {
                var newFood = Food.Create(
            id: FoodId.Of(Guid.NewGuid()),
                name: food.Name,
                calories: food.Calories,
                description: food.Description,
            foodCategory: food.FoodCategory
            );

                newMeal.AddFood(newFood);
              
            }
            foreach (var comment in meal.Comments)
            {
                var newComment = Comment.Create(
            id: CommentId.Of(Guid.NewGuid()),
            label: comment.Label ,
            content : comment.Content );

                newMeal.AddComments(newComment);

            }
            newDiet.AddMeal(newMeal);
        }
        foreach (var allergy in dietDto.Register.Allergies) 
        {
            newDiet.Register.AddAllergy(allergy.ToSimpleRiskEntity());
        }
        foreach (var disease in dietDto.Register.Diseases)
        {
            newDiet.Register.AddDisease(disease.ToSimpleRiskEntity());
        }
        return newDiet;

    }
}