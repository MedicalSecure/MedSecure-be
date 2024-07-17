using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Application.Diets.Commands.DeleteDiet
{

    public class DeleteDietHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<DeleteDietCommand, DeleteDietResult>
    {
        public async Task<DeleteDietResult> Handle(DeleteDietCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var diet = Domain.Models.Diet.Create(DietId.Of(id), null , null ,null , null , null);

            Guid createdBy = Guid.NewGuid();
            var newActivity = Domain.Models.Activity.Create(createdBy, $"deleted new {nameof(diet)}", "Tiss Rahma");
            dbContext.Activities.Add(newActivity);

            dbContext.Diets.Remove(diet);

            await dbContext.SaveChangesAsync(cancellationToken);



            // return result containing the ID of the deleted unitcare
            return new DeleteDietResult(true);
        }
    }
}