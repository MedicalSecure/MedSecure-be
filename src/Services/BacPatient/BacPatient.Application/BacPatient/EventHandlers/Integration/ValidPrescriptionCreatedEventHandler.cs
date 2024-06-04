using BacPatient.Application.Config;
using BuildingBlocks.Messaging.Events.Drugs;
using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BacPatient.Application.BacPatient.EventHandlers.Integration
{
    //public class ValidPrescriptionCreatedEventHandler(RegistrationMicroserviceSettings _settings, HttpClient _httpClient) : IConsumer<ValidatedPrescriptionSharedEvent>
    public class ValidPrescriptionCreatedEventHandler(HttpClient _httpClient) : IConsumer<ValidatedPrescriptionSharedEvent>
    {
        public async Task Consume(ConsumeContext<ValidatedPrescriptionSharedEvent> context)
        {
            var x = context.Message;
            if (x == null)
                return;
            var newPrescription = await CreateSimplePrescriptionFromEvent(x);
            // Continue here
            Console.WriteLine(x);
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
            var simplePosology = new SimplePosologyDto(x.Id,x.PrescriptionId, simpleMed,x.StartDate,x.EndDate,x.IsPermanent, simpleComments, simpleDispenses);
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
                return Route.Pills; // or throw an exception, or return a default value, etc.
            }
        }

        public async Task<SimpleRegisterDto?> fetchSimpleRegisterById(Guid registerId)
        {
            //var url = $"{_settings.GetByIdEndpoint}/{registerId}";
            var url = $"http://registration.api:8080/registers/{registerId}";

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
    }
}