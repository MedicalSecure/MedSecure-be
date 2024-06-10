using BacPatient.Application.BacPatient.Commands.CreateBPModel;
using BacPatient.Application.BPModels.Commands.CreateBacPatient;
using BacPatient.Application.Extensions.SimpleBacPatientExtension;
using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Threading;

namespace BacPatient.Application.BacPatient.EventHandlers.Integration
{
    public class ValidPrescriptionCreatedEventHandler(IConfiguration config, HttpClient _httpClient , IPublishEndpoint publishEndpoint, IApplicationDbContext dbContext) : IConsumer<ValidatedPrescriptionSharedEvent>
    {

        public async Task Consume(ConsumeContext<ValidatedPrescriptionSharedEvent> context)
        {
            int toServe = 0;

            var x = context.Message;
            if (x == null)
                return;
            var newPrescription = await CreateSimplePrescriptionFromEvent(x);
            foreach (var Posology in newPrescription.Posologies)
            {
                foreach (var Dispense in Posology.Dispenses)
                {
                    int beforeMealQuantity = int.Parse(Dispense.BeforeMeal?.Quantity ?? "0");
                    int afterMealQuantity = int.Parse(Dispense.AfterMeal?.Quantity ?? "0");
                     toServe = beforeMealQuantity + afterMealQuantity;
                }
            }

            Console.WriteLine(newPrescription);

            var createBacPatientCommand = new CreateBacPatientCommand(new BacPatientDto(Guid.NewGuid(), newPrescription, Guid.NewGuid(), 0, toServe, StatusBP.Pending));
            var result =  CreateNewBP(new BacPatientDto(Guid.NewGuid(), newPrescription, Guid.NewGuid(), 0, toServe, StatusBP.Pending));
            dbContext.BacPatients.Add(result);
            await dbContext.SaveChangesAsync(default);

        }

        private async Task<SimplePrescriptionDto?> CreateSimplePrescriptionFromEvent(ValidatedPrescriptionSharedEvent x)
        {
            var simpleUnitCare = CreateSimpleUnitCare(x.UnitCare, x.BedId) ?? throw new ArgumentNullException("Cant extract a simple unitCare from this prescription");
            var getSimpleRegister = await fetchSimpleRegisterById(x.RegisterId);

            var simplePosologies = x.Posologies.Select(p => CreateSimplePosology(p)).ToList();

            var newPrescription = new SimplePrescriptionDto(
                        Id: x.Id,
                        Register: getSimpleRegister,
                        CreatedAt: x.CreatedAt,
                        Posologies: simplePosologies,
                        UnitCare: simpleUnitCare
                        );

            return newPrescription;
        }

        private SimplePosologyDto CreateSimplePosology(PosologySharedEvent x)
        {
            var simpleMed = CreateSimpleMedication(x.Medication);
            var simpleComments = x.Comments.Adapt<ICollection<SimpleCommentsDto>>();
            var simpleDispenses = x.Dispenses.Adapt<ICollection<SimpleDispensesDto>>();
            var simplePosology = new SimplePosologyDto(x.Id, x.PrescriptionId, simpleMed, x.StartDate, x.EndDate, x.IsPermanent, simpleComments, simpleDispenses);
            return simplePosology;
        }

        private SimpleUnitCareDto CreateSimpleUnitCare(UnitCarePlanSharedEvent unit, Guid BedId)
        {
            var simpleRoom = FindRoomWithBed(unit, BedId) ?? throw new ArgumentNullException("Cant extract a simple room from for this prescription");
            //the room cant be mapped automatically
            var simpleUnitCare = unit.Adapt<SimpleUnitCareDto>() with { Room = simpleRoom };
            return simpleUnitCare;
        }

        private SimpleRoomDto? FindRoomWithBed(UnitCarePlanSharedEvent unitCarePlanEvent, Guid bedId)
        {
            foreach (var room in unitCarePlanEvent.Rooms)
            {
                var bedEquipment = room.Equipments.FirstOrDefault(e => e.Id == bedId);
                if (bedEquipment != null)
                {
                    var simpleRoom = room.Adapt<SimpleRoomDto>() with { Equipment = bedEquipment.Adapt<SimpleEquipmentDto>() };
                    return simpleRoom;
                }
            }

            return null;
        }

        private SimpleMedicationDto CreateSimpleMedication(DrugSharedEvent drug)
        {
            var route = ParseRoute(drug.Route);
            var simpleMedication = new SimpleMedicationDto(drug.Id, drug.Name, drug.Dosage, route, drug.Description ?? "");
            return simpleMedication;
        }

        public static Route ParseRoute(int routeValue)
        {
            if (Enum.IsDefined(typeof(Route), routeValue))
            {
                return (Route)routeValue;
            }
            else
            {
                // Handle the case when the routeValue doesn't correspond to a valid Route enum value
                return Route.Pills; 
            }
        }

        public async Task<SimpleRegisterDto?> fetchSimpleRegisterById(Guid registerId)
        {
            var url = $"{config["RegistrationMicroservice:GetByIdEndpoint"]}/{registerId}";
          // var url = $"http://localhost:6010/registers/{registerId}";

            try
            {
                // Send a GET request to the specified URL
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into a User object
                var mappedResponse = JsonConvert.DeserializeObject<GetByIdSimpleRegisterResponse>(responseBody);
                var register = mappedResponse?.Register;
                return register;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public record GetByIdSimpleRegisterResponse(SimpleRegisterDto Register);
        private static Domain.Models.BacPatient CreateNewBP(BacPatientDto bacPatients)
        {
            var newBPModel = Domain.Models.BacPatient.Create(
                Id: BacPatienId.Of(Guid.NewGuid()),
                Prescription: Prescription.Create(
                    Register: Register.Create(
                        id: RegisterId.Of(Guid.NewGuid()),
                         patient: Patient.Create(
                        bacPatients.Prescription.Register.Patient.FirstName,
                        bacPatients.Prescription.Register.Patient.LastName,
                        bacPatients.Prescription.Register.Patient.DateOfbirth)

                         ),
                    UnitCare: UnitCare.Create(
                                                id: UnitCareId.Of(Guid.NewGuid()),
                                                title: bacPatients.Prescription.UnitCare.Title,
                                                description: bacPatients.Prescription.UnitCare.Description,
                                                room: Room.Create(id: RoomId.Of(Guid.NewGuid()),
                                               roomNumber: bacPatients.Prescription.UnitCare.Room.RoomNumber,
                                                status: bacPatients.Prescription.UnitCare.Room.Status,
                                                equipment: Equipment.Create(
                                                    id: EquipmentId.Of(Guid.NewGuid()),
                                                    reference: bacPatients.Prescription.UnitCare.Room.Equipment.Reference)

                    )
                                                ),

                    CreatedAt: bacPatients.Prescription.CreatedAt
                    ),

                    NurseId: bacPatients.NurseId,
                    Served: bacPatients.Served,
                    ToServe: bacPatients.ToServe,
                    Status: bacPatients.Status

            );
            foreach (var posology in bacPatients.Prescription.Posologies)
            {
                var newPos = Posology.Create(PrescriptionId.Of(posology.PrescriptionId), posology.Medication.ToSimpleMedicineEntity(), posology.StartDate, posology.EndDate, posology.IsPermanent);
                newBPModel.Prescription.addPosology(newPos);
                foreach (var comment in posology.Comments)
                {
                    var newComment = Comment.Create(PosologyId.Of(comment.PosologyId), comment.Label, comment.Content);
                    newPos.AddComment(newComment);
                }
                foreach (var dispense in posology.Dispenses)
                {
                    var newDispense = Dispense.Create(PosologyId.Of(dispense.PosologyId), dispense.Hour, dispense.BeforeMeal, dispense.AfterMeal);
                    newPos.AddDispense(newDispense);
                }
            }
            return newBPModel;
        }
    }
}