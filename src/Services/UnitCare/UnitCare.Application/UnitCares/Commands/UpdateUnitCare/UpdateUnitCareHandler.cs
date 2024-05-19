using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Application.Dtos;

namespace UnitCare.Application.UnitCares.Commands.UpdateUnitCare;

public class UpdateUnitCareHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateUnitCareCommand, UpdateUnitCareResult>
{
public async Task<UpdateUnitCareResult> Handle(UpdateUnitCareCommand command, CancellationToken cancellationToken)
{
    // Update UnitCare entity from command object
    // save to database
    // return result
    var unitCareId = UnitCareId.Of(command.UnitCare.Id);
    var unitCare = await dbContext.UnitCares.FindAsync([unitCareId], cancellationToken);

    if (unitCare == null)
    {
        throw new UnitCareNotFoundException(command.UnitCare.Id);
    }

       UpdateUnitCareWithNewValues(unitCare, command.UnitCare);

    dbContext.UnitCares.Update(unitCare);
    await dbContext.SaveChangesAsync(cancellationToken);

    return new UpdateUnitCareResult(true);
    }

private static void UpdateUnitCareWithNewValues(Domain.Models.UnitCare unitCare, UnitCareDto unitCareDto)
{
        unitCare.Update(unitCareDto.Title, unitCareDto.Description, unitCareDto.Type,unitCareDto.UnitStatus);
}
}
