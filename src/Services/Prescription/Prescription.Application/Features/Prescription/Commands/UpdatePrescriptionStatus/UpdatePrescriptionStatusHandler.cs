﻿using BuildingBlocks.Exceptions;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Prescription.Application.Contracts;
using Prescription.Application.Exceptions;
using Prescription.Application.Features.UnitCare.Queries;
using Prescription.Domain.Entities;
using Prescription.Domain.Entities.UnitCareRoot;
using Prescription.Domain.ValueObjects;

namespace Prescription.Application.Features.Prescription.Commands.UpdatePrescriptionStatus
{
    public class UpdatePrescriptionStatusHandler : ICommandHandler<UpdatePrescriptionStatusCommand, UpdatePrescriptionStatusResult>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly TypeAdapterConfig _mapsterConfig;

        public UpdatePrescriptionStatusHandler(IApplicationDbContext dbContext, TypeAdapterConfig mapsterConfig)
        {
            _dbContext = dbContext;
            _mapsterConfig = mapsterConfig;
        }

        public async Task<UpdatePrescriptionStatusResult> Handle(UpdatePrescriptionStatusCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var prescriptionId = PrescriptionId.Of(command.Prescription?.Id
                    ?? throw new BadRequestException($"{nameof(Prescription)} : Updating prescription Status Require an ID"));

                // Get the old prescription from DB so we can update the status
                var oldPrescription = await _dbContext.Prescriptions.FindAsync([prescriptionId], cancellationToken)
                    ?? throw new NotFoundException($"{nameof(Prescription)} : Can't find prescription to update Status with the given id : {prescriptionId.Value}");

                var newStatus = command.Prescription.Status;
                // the new prescription is valid (didn't throw exception) so we can update the status of the old one
                oldPrescription.UpdateStatus(newStatus);

                // the UpdateStatus Didn't throw a an exception => the new status (Discontinued) is valid relative to the old one, we can save changes!
                _dbContext.Prescriptions.Update(oldPrescription);

                //Create corresponding activity
                Guid createdBy = Guid.NewGuid();
                string message = newStatus == PrescriptionStatus.Discontinued ? "Suspended a prescription" : "Updated Prescription Status";
                var newActivity = Domain.Entities.Activity.Create(createdBy, message, "Hammadi AZ");
                _dbContext.Activities.Add(newActivity);

                // Same the 3 changes : update old prescription (discontinued), Add the new one AND Add an activity
                await _dbContext.SaveChangesAsync(cancellationToken);
                // Return result
                return new UpdatePrescriptionStatusResult(prescriptionId.Value);
            }
            catch (Exception ex)
            {
                // Option 1: Return a custom error result
                //return new UpdatePrescriptionResult(Guid.Empty);

                // Option 2: Throw a custom exception with the error message
                throw new UpdatePrescriptionException(ex.Message, ex);
            }
        }
    }
}