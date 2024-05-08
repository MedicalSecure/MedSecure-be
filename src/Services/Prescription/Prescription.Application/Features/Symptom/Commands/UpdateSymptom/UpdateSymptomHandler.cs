using Prescription.Application.Contracts;
using Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prescription.Application.Exceptions;

namespace Prescription.Application.Features.Symptom.Commands.UpdateSymptom
{
    public class UpdateSymptomHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateSymptomCommand, UpdateSymptomResult>
    {
        public async Task<UpdateSymptomResult> Handle(UpdateSymptomCommand command, CancellationToken cancellationToken)
        {
            // Update Symptom entity from command object
            // save to database
            // return result
            var Symptom = await dbContext.Symptoms.FindAsync([command.Symptom.Id], cancellationToken);

            if (Symptom == null)
            {
                throw new SymptomNotFoundException(command.Symptom.Id);
            }

            UpdateSymptomWithNewValues(Symptom, command.Symptom);
            dbContext.Symptoms.Update(Symptom);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateSymptomResult(Symptom.Id.Value);
        }

        private static void UpdateSymptomWithNewValues(Domain.Entities.Symptom Symptom, SymptomDto SymptomDto)
        {
            Symptom.Update(SymptomDto.Code, SymptomDto.Name, SymptomDto.ShortDescription, SymptomDto.LongDescription);
        }
    }
}