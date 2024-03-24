using Diet.Application.Dtos;
using Diet.Domain.Enums;
using Diet.Domain.ValueObjects;

namespace Diet.Application.Diets.Commands.CreateFood;

public class CreateFoodHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateFoodCommand, CreateFoodResult>
{
    public async Task<CreateFoodResult> Handle(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        // create Food entity from command object
        // save to database
        // return result
        var food = CreateNewFood(command.Food);

        dbContext.Foods.Add(food);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateFoodResult(food.Id.Value);
    }

    private static Food CreateNewFood(FoodDto foodDto)
    {
        //FoodId id, string name, decimal calories, string description
        var newFood = Food.Create(
            id: FoodId.Of(Guid.NewGuid()),
            mealId: MealId.Of(foodDto.MealId),
            name: foodDto.Name,
            calories: foodDto.Calories,
            description: foodDto.Description,
            foodCategory: foodDto.FoodCategory
            );

        return newFood;
    }
}