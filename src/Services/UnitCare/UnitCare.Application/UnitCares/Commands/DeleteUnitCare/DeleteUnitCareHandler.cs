using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Application.Dtos;
using UnitCare.Domain.Models;

namespace UnitCare.Application.UnitCares.Commands.DeleteUnitCare
{

    public class DeleteUnitCareHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<DeleteUnitCareCommand, DeleteUnitCareResult>
    {
        public async Task<DeleteUnitCareResult> Handle(DeleteUnitCareCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var unitcare = Domain.Models.UnitCare.Create(UnitCareId.Of(id), null, null, null, 0);

            Guid createdBy = Guid.NewGuid();
            var newActivity = Domain.Models.Activity.Create(createdBy, $"deleted new {nameof(unitcare)}", "Ranim.M");
            dbContext.Activities.Add(newActivity);

            dbContext.UnitCares.Remove(unitcare);

            await dbContext.SaveChangesAsync(cancellationToken);

    

            // return result containing the ID of the deleted unitcare
            return new DeleteUnitCareResult(true);
        }
    }
}
