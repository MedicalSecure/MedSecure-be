using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Application.Dtos;

namespace UnitCare.Application.UnitCares.Commands.DeleteUnitCare
{

    public class DeleteUnitCareHandler(IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext, IFeatureManager featureManager) : ICommandHandler<DeleteUnitCareCommand, DeleteUnitCareResult>
    {
        public async Task<DeleteUnitCareResult> Handle(DeleteUnitCareCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var unitcare = Domain.Models.UnitCare.Create(UnitCareId.Of(id), null, null, null, 0);

            dbContext.UnitCares.Remove(unitcare);

            await dbContext.SaveChangesAsync(cancellationToken);

    

            // return result containing the ID of the deleted unitcare
            return new DeleteUnitCareResult(true);
        }
    }
}
