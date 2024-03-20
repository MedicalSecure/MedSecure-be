
namespace Diet.Application.Foods.Commands.UpdateDiet;

public class UpdateFoodHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateFoodCommand, UpdateFoodResult>
{
    public async Task<UpdateFoodResult> Handle(UpdateFoodCommand command, CancellationToken cancellationToken)
    {
        // Update Food entity from command object
        // save to database
        // return result
        var foodId = FoodId.Of(command.Food.Id);
        var food = await dbContext.Foods.FindAsync([foodId], cancellationToken);

        if (food == null)
        {
            throw new FoodNotFoundException(command.Food.Id);
        }

        UpdateFoodWithNewValues(food, command.Food);

        dbContext.Foods.Update(food);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateFoodResult(true);
    }

    private static void UpdateFoodWithNewValues(Food food, FoodDto foodDto)
    {
        food.Update(foodDto.Name, foodDto.Calories, foodDto.Description);
    }
}