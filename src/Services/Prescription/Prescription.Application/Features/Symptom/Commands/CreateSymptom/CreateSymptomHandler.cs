using Prescription.Application.Contracts;
using Prescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.Features.Symptom.Commands.CreateSymptom
{
    public class UpdateSymptomHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateSymptomCommand, CreateSymptomResult>
    {
        public async Task<CreateSymptomResult> Handle(CreateSymptomCommand command, CancellationToken cancellationToken)
        {
            // create Symptom entity from command object
            // save to database
            // return result
            var Symptom = CreateNewSymptom(command.Symptom);
            Guid createdBy = Guid.NewGuid();

            dbContext.Symptoms.Add(Symptom);
            await dbContext.SaveChangesAsync(cancellationToken);

            var newActivity = Domain.Entities.Activity.Create(createdBy, "created new symptom", "Hammadi AZ");
            dbContext.Activities.Add(newActivity);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateSymptomResult(Symptom.Id.Value);
        }

        private static Domain.Entities.Symptom CreateNewSymptom(SymptomDto SymptomDto)
        {
            var newSymptom = Domain.Entities.Symptom.Create(SymptomDto.Code, SymptomDto.Name, SymptomDto.ShortDescription, SymptomDto.LongDescription);
            return newSymptom;
        }
    }
}