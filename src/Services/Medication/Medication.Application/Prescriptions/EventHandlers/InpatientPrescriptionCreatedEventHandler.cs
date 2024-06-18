using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Medication.Application.Hubs;
using Medication.Application.Hubs.Abstractions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;

namespace Medication.Application.Prescriptions.EventHandlers
{
    public class InpatientPrescriptionCreatedEventHandler : IConsumer<InpatientPrescriptionSharedEvent>
    {
        private readonly ISender _sender;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IApplicationDbContext _dbContext;
        private readonly IPharmaLinkHub _hubContext;

        public InpatientPrescriptionCreatedEventHandler(ISender sender,
            IPublishEndpoint publishEndpoint,
            IApplicationDbContext dbContext,
            IPharmaLinkHub hubContext)
        {
            _sender = sender;
            _publishEndpoint = publishEndpoint;
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<InpatientPrescriptionSharedEvent> context)
        {
            var p = context.Message;

            //continue preparing the event
            var jsonUnitCare = JsonConvert.SerializeObject(p.UnitCare);
            var drugs = await _dbContext.Drugs.ToListAsync();
            if (drugs == null)
            {
                Console.WriteLine("No drugs in DB");
                return;
            }

            string rejectionMessages = GetRejectionMessage(p, drugs, out Dictionary<DrugId, int> ReservedQuantities);

            if (rejectionMessages == string.Empty)
            {
                //valid => create a Pending validation for the pharmacy to Validate manually later
                var newValidation = CreateValidationFromEvent(p, drugs);
                try
                {
                    foreach (var drugId in ReservedQuantities.Keys)
                    {
                        var drug = drugs.FirstOrDefault(d => d.Id == drugId);
                        if (drug == null)
                            return;//impossible case, car this validation has occurred in : CreateValidationFromEvent from above

                        drug.ReserveStock(ReservedQuantities[drugId]);
                        //_dbContext.Drugs.Update(drug);
                    }

                    _dbContext.Validations.Add(newValidation);
                    await _dbContext.SaveChangesAsync(CancellationToken.None);

                    //Success saving db => Send notification to front:
                    await _hubContext.SendEventToAll(p);

                    //Add new Activity
                    Guid createdBy = Guid.NewGuid();
                    var newActivity = Activity.Create(createdBy, $"Received a new prescription to validate", "System");
                    _dbContext.Activities.Add(newActivity);
                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);// if the event occurred twice for the same prescription => just log it and return ..
                }
                //Finished
                return;
            }

            var isPrescriptionValid = false;//Rejection
            string RejectedBy = "System";
            // Not enough stock available / Medication not found error :
            var validatedPrescriptionEvent = new PrescriptionValidationSharedEvent(p.Id, Guid.Empty, RejectedBy, jsonUnitCare, isPrescriptionValid, rejectionMessages);
            await _publishEndpoint.Publish(validatedPrescriptionEvent);
        }

        private static string GetRejectionMessage(InpatientPrescriptionSharedEvent p, List<Drug> drugs, out Dictionary<DrugId, int> ReservedQuantities)
        {
            ReservedQuantities = new Dictionary<DrugId, int>();
            string rejectionMessages = string.Empty;//Messages separated by #

            foreach (var posology in p.Posologies)
            {
                var drug = drugs.FirstOrDefault(d => d.Id == DrugId.Of(posology.Medication.Id));
                if (drug == null)
                {
                    //Reset the rejection message (dont += to its old values)
                    rejectionMessages = $"Error : Can't find medication with id : {posology.Medication.Id}, from event id {p.EventId}";
                    Console.WriteLine(rejectionMessages);//TODO => move to log

                    break;//continue to rejection, dont continue the calculation
                }

                var availableStock = drug.AvailableStock;
                int quantityNeeded = 0;

                foreach (var dispense in posology.Dispenses)
                {
                    var dispenseBeforeMeal = dispense.BeforeMeal?.Quantity ?? 0;
                    var dispenseAfterMeal = dispense.AfterMeal?.Quantity ?? 0;

                    quantityNeeded += dispenseBeforeMeal + dispenseAfterMeal;
                }

                if (ReservedQuantities.ContainsKey(drug.Id))
                {
                    //this handle the case where the medication existed more than one time inside the posology list
                    //example list posology of 5, 3 of them are the medication X,
                    quantityNeeded += ReservedQuantities[drug.Id];
                }

                if (quantityNeeded > availableStock)
                {
                    // Not enough stock available
                    rejectionMessages += $"#Quantity of Medication {drug.Name} insufficient: Requested {quantityNeeded} | Available : {availableStock}";
                }
                else
                {
                    //reserve stock
                    if (ReservedQuantities.ContainsKey(drug.Id))
                    {
                        //the sum is already updated above
                        ReservedQuantities[drug.Id] = quantityNeeded;
                    }
                    else
                    {
                        //add the new quantity
                        ReservedQuantities.Add(drug.Id, quantityNeeded);
                    }
                }
            }

            return rejectionMessages;
        }

        private Validation CreateValidationFromEvent(InpatientPrescriptionSharedEvent ev, List<Drug> drugs)
        {
            var jsonUnitCare = JsonConvert.SerializeObject(ev.UnitCare);
            var validation = Validation.Create(ev.Id, jsonUnitCare);
            foreach (var posology in ev.Posologies)
            {
                var drug = drugs.FirstOrDefault(d => d.Id == DrugId.Of(posology.MedicationId));
                if (drug == null)
                    throw new NotFoundException($"Drug with id {posology.MedicationId} not found");
                var newPosology = Posology.Create(validation.Id, drug.Id);

                foreach (var comment in posology.Comments)
                {
                    var newComment = Comment.Create(newPosology.Id, comment.Label, comment.Content, "Hammadi Phar", DateTime.UtcNow);
                    if (newComment != null)
                        newPosology.AddComment(newComment);
                }

                foreach (var dispense in posology.Dispenses)
                {
                    var disp = Dispense.Create(newPosology.Id, dispense.Hour, dispense.BeforeMeal?.Quantity, dispense.AfterMeal?.Quantity, "Hammadi Phar", DateTime.UtcNow);
                    if (disp != null)
                        newPosology.AddDispense(disp);
                }

                validation.addPosology(newPosology);
            }

            return validation;
        }
    }
}