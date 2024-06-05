﻿using BuildingBlocks.Messaging.Events.PrescriptionEvents;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacPatient.Application.testEvents
{
    public record TestEventQuery(string eventName = "valid") : IQuery<TestEventResult>;
    public record TestEventResult(string eventNameResult = "valid");

    public class TestEventsEmitter(IPublishEndpoint publishEndpoint) : IQueryHandler<TestEventQuery, TestEventResult>
    {
        public async Task<TestEventResult> Handle(TestEventQuery request, CancellationToken cancellationToken)
        {
            if (request.eventName == "validPrescriptionEvent")
            {
                var valid = JsonConvert.DeserializeObject<ValidatedPrescriptionSharedEvent>(validPrescriptionJson)
                    ?? throw new ArgumentNullException("validPrescriptionJson is null");
                await publishEndpoint.Publish(valid, cancellationToken);
            }
            else
            {
                var discontinued = JsonConvert.DeserializeObject<DiscontinuedInpatientPrescriptionSharedEvent>(discontinuedPrescriptionJson)
                    ?? throw new ArgumentNullException("discontinuedPrescriptionJson is null"); ;
                await publishEndpoint.Publish(discontinued, cancellationToken);
            }

            return new TestEventResult(request.eventName);
        }

        public string validPrescriptionJson = "{\"Id\":\"0c611a32-4479-4a78-a2be-09b0d2e335bf\",\"RegisterId\":\"88888888-8888-8888-8888-888888888888\",\"DoctorId\":\"55555555-5555-5555-5555-555555555554\",\"PharmacistId\":\"9b5809ea-44c9-4fd5-895f-428b74e77f13\",\"BedId\":\"94d59c6a-ffa6-401f-a065-f1d8e74f4d67\",\"Status\":2,\"Symptoms\":[{\"Id\":\"b26b34b6-a5f0-4434-a30e-0408da222d9a\",\"Code\":\"39\",\"Name\":\"Abdominal pain\",\"ShortDescription\":\"Abdominal pain\",\"LongDescription\":\"Abdominal pain\"},{\"Id\":\"c894b12a-68c4-4002-82e0-ebeb03653cac\",\"Code\":\"8\",\"Name\":\"Acidity\",\"ShortDescription\":\"Acidity\",\"LongDescription\":\"Acidity\"}],\"Diagnoses\":[{\"Id\":\"7b647c8f-11eb-4b8d-be4c-209638edbf9a\",\"Code\":\"L70.0\",\"Name\":\"Acne\",\"ShortDescription\":\"Skin condition causing pimples and blackheads\",\"LongDescription\":\"A common skin condition that occurs when hair follicles become clogged with dead skin cells and oil, causing pimples and blackheads\"},{\"Id\":\"b8cb7d46-0548-474b-887f-efeee0e0a350\",\"Code\":\"B24\",\"Name\":\"AIDS\",\"ShortDescription\":\"Acquired immunodeficiency syndrome\",\"LongDescription\":\"An acquired immunodeficiency syndrome caused by the human immunodeficiency virus (HIV), which attacks the body's immune system\"}],\"Posologies\":[{\"Id\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"PrescriptionId\":\"0c611a32-4479-4a78-a2be-09b0d2e335bf\",\"MedicationId\":\"fe44c53e-b711-4fe7-851a-67521744463c\",\"Medication\":{\"Id\":\"fe44c53e-b711-4fe7-851a-67521744463c\",\"Name\":\"Paracetamol\",\"Dosage\":\"250 mg\",\"Form\":\"Tablet\",\"Code\":\"A2020\",\"Unit\":\"mg\",\"Description\":\"Nonsteroidal anti-inflammatory drug (NSAID).\",\"ExpiredAt\":\"2027-06-04T12:07:51.754\",\"Stock\":20,\"AvailableStock\":null,\"AlertStock\":15,\"AvrgStock\":10,\"MinStock\":7,\"SafetyStock\":3,\"ReservedStock\":1,\"Price\":6.9900,\"Route\":11},\"StartDate\":\"2024-06-09T23:00:00\",\"EndDate\":\"2024-06-13T23:00:00\",\"IsPermanent\":false,\"Comments\":[{\"Id\":\"3191b4be-07fe-4ab8-99dc-66842510dadf\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Label\":\"Comment\",\"Content\":\"test normal comment for paracetamol 10 - 14\"}],\"Dispenses\":[{\"Id\":\"52ddcb59-928e-4d75-91aa-454bae5ec1f2\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":0,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"b1c13725-6a33-40c9-b96e-4c040af88052\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":17,\"BeforeMeal\":{\"Quantity\":22,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"232b670c-c4fe-4cde-b06b-5d3c0bef659f\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":14,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"570e8731-42cb-46c4-a899-5fc2660eaaab\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":11,\"BeforeMeal\":{\"Quantity\":6,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"c5f37b82-ea7f-4ede-8a9f-a9995b0d7a27\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":2,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null}]},{\"Id\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"PrescriptionId\":\"0c611a32-4479-4a78-a2be-09b0d2e335bf\",\"MedicationId\":\"7d524d8d-4ff9-46d8-a5c3-866b8e7ec2cf\",\"Medication\":{\"Id\":\"7d524d8d-4ff9-46d8-a5c3-866b8e7ec2cf\",\"Name\":\"Aspirin\",\"Dosage\":\"500 mg\",\"Form\":\"Tablet\",\"Code\":\"A1010\",\"Unit\":\"B/90\",\"Description\":\"Pain reliever and anti-inflammatory medication.\",\"ExpiredAt\":\"2026-06-04T12:07:51.753\",\"Stock\":20,\"AvailableStock\":null,\"AlertStock\":18,\"AvrgStock\":13,\"MinStock\":8,\"SafetyStock\":4,\"ReservedStock\":2,\"Price\":5.9900,\"Route\":11},\"StartDate\":\"2024-06-15T23:00:00\",\"EndDate\":\"2024-06-21T23:00:00\",\"IsPermanent\":false,\"Comments\":[{\"Id\":\"85c80596-8d13-4910-afe0-14e9ed311464\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Label\":\"Caution\",\"Content\":\"test caution comment for aspirin  16 - 22\"},{\"Id\":\"126385b0-25de-4f75-ba3d-d5da7b14d5c2\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Label\":\"Comment\",\"Content\":\"test normal comment for aspirin  16 - 22\"}],\"Dispenses\":[{\"Id\":\"97ccd8b2-11bc-4488-8df3-1a02decd9bb5\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":14,\"BeforeMeal\":null,\"AfterMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false}},{\"Id\":\"58f6f2c9-1393-4218-a6ff-48ae0cb19454\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":15,\"BeforeMeal\":{\"Quantity\":6,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"ebb0f79b-0e4f-441c-8ec1-4c4c2e35e7ee\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":12,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"d97579c5-0ec3-4f6a-b8c2-5252f8394ca2\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":0,\"BeforeMeal\":{\"Quantity\":7,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"024b4119-ba51-4b45-b60d-8882935d4e30\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":1,\"BeforeMeal\":{\"Quantity\":6,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":{\"Quantity\":3,\"IsValid\":false,\"IsPostValid\":false}},{\"Id\":\"adee02d1-f6fe-445b-b342-b62c7cb46d25\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":2,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":{\"Quantity\":4,\"IsValid\":false,\"IsPostValid\":false}}]}],\"UnitCare\":{\"Id\":\"f0566a67-c314-416a-b32c-6f3c75df0166\",\"Title\":null,\"Description\":null,\"Type\":null,\"UnitStatus\":0,\"Rooms\":[{\"Id\":\"e2effd33-02b2-4e8a-88a1-ad2676bfbc81\",\"RoomNumber\":103,\"Status\":1,\"Equipments\":[{\"Id\":\"06fb6a3d-d758-4b20-a081-3f8d9afb6922\",\"Name\":\"Matériel de perfusion \",\"Reference\":\"253DMT\",\"EqStatus\":2,\"EqType\":7},{\"Id\":\"60cfe9d1-9121-48bd-8d03-6c6ec2b423f9\",\"Name\":\"Défibrillateurs\",\"Reference\":\"25354DMT\",\"EqStatus\":2,\"EqType\":15},{\"Id\":\"9069ccb6-10e1-40b1-b748-755f25eb76d2\",\"Name\":\"Bed\",\"Reference\":\"21354DMT\",\"EqStatus\":1,\"EqType\":4}]},{\"Id\":\"037f549a-29d1-41f5-9034-faec0894e7d6\",\"RoomNumber\":102,\"Status\":1,\"Equipments\":[{\"Id\":\"b7ba95c4-2e7e-464f-a51e-61a9cf15865a\",\"Name\":\"Respirateurs\",\"Reference\":\"21354DMT\",\"EqStatus\":2,\"EqType\":6},{\"Id\":\"94d59c6a-ffa6-401f-a065-f1d8e74f4d67\",\"Name\":\"Bed\",\"Reference\":\"253DMT\",\"EqStatus\":2,\"EqType\":1},{\"Id\":\"e67a27c9-27d6-4703-8d5e-ff46061b1e40\",\"Name\":\"TABLE\",\"Reference\":\"25354DMT\",\"EqStatus\":1,\"EqType\":9}]}],\"Personnels\":[{\"Id\":\"fc5d9b64-a282-40f9-a5b5-594b20465d23\",\"Name\":\"emily\",\"Shift\":2,\"Gender\":2},{\"Id\":\"1ec7e37f-b647-4938-bc6e-ffac1243c8c0\",\"Name\":\"olivier\",\"Shift\":1,\"Gender\":1}],\"EventId\":\"bdc07a07-efc2-4b73-a753-4ac350e4b9c1\",\"OccurredOn\":\"2024-06-04T13:11:05.5507882+00:00\",\"EventType\":\"BuildingBlocks.Messaging.Events.UnitCarePlanSharedEvent, BuildingBlocks.Messaging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\"},\"Diet\":{\"Id\":\"4575e2f6-9ff0-4fe1-a55f-80172c0363e7\",\"StartDate\":\"2024-06-05T00:00:00\",\"EndDate\":\"2024-06-16T00:00:00\",\"DietsId\":[\"1fabbdfd-8887-4d33-9773-2b2185f6a9e1\"]},\"PharmacistName\":\"Hammadi Phar\",\"Remarques\":\"no remarques\",\"CreatedAt\":\"2024-06-04T13:10:08.2232202\",\"EventId\":\"a7d092fa-4b5a-4323-adac-6fb09b2e9037\",\"OccurredOn\":\"2024-06-04T13:11:05.5517431+00:00\",\"EventType\":\"BuildingBlocks.Messaging.Events.PrescriptionEvents.ValidatedPrescriptionSharedEvent, BuildingBlocks.Messaging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\"}\r\n";
        public string discontinuedPrescriptionJson = "{\"Id\":\"0c611a32-4479-4a78-a2be-09b0d2e335bf\",\"RegisterId\":\"88888888-8888-8888-8888-888888888888\",\"DoctorId\":\"55555555-5555-5555-5555-555555555554\",\"Status\":4,\"BedId\":\"94d59c6a-ffa6-401f-a065-f1d8e74f4d67\",\"Posologies\":[{\"Id\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"PrescriptionId\":\"0c611a32-4479-4a78-a2be-09b0d2e335bf\",\"MedicationId\":\"fe44c53e-b711-4fe7-851a-67521744463c\",\"Medication\":{\"Id\":\"fe44c53e-b711-4fe7-851a-67521744463c\",\"Name\":\"Paracetamol\",\"Dosage\":\"250 mg\",\"Form\":\"Tablet\",\"Code\":\"A2020\",\"Unit\":\"mg\",\"Description\":\"Nonsteroidal anti-inflammatory drug (NSAID).\",\"ExpiredAt\":\"2027-06-04T11:07:51.754Z\",\"Stock\":20,\"AvailableStock\":null,\"AlertStock\":15,\"AvrgStock\":10,\"MinStock\":7,\"SafetyStock\":3,\"ReservedStock\":1,\"Price\":6.99,\"Route\":11},\"StartDate\":\"2024-06-09T22:00:00Z\",\"EndDate\":\"2024-06-13T22:00:00Z\",\"IsPermanent\":false,\"Comments\":[{\"Id\":\"3191b4be-07fe-4ab8-99dc-66842510dadf\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Label\":\"Comment\",\"Content\":\"test normal comment for paracetamol 10 - 14\"}],\"Dispenses\":[{\"Id\":\"52ddcb59-928e-4d75-91aa-454bae5ec1f2\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":0,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"b1c13725-6a33-40c9-b96e-4c040af88052\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":17,\"BeforeMeal\":{\"Quantity\":22,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"232b670c-c4fe-4cde-b06b-5d3c0bef659f\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":14,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"570e8731-42cb-46c4-a899-5fc2660eaaab\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":11,\"BeforeMeal\":{\"Quantity\":6,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"c5f37b82-ea7f-4ede-8a9f-a9995b0d7a27\",\"PosologyId\":\"df607559-d888-4f30-8d53-8e82b1f389ef\",\"Hour\":2,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null}]},{\"Id\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"PrescriptionId\":\"0c611a32-4479-4a78-a2be-09b0d2e335bf\",\"MedicationId\":\"7d524d8d-4ff9-46d8-a5c3-866b8e7ec2cf\",\"Medication\":{\"Id\":\"7d524d8d-4ff9-46d8-a5c3-866b8e7ec2cf\",\"Name\":\"Aspirin\",\"Dosage\":\"500 mg\",\"Form\":\"Tablet\",\"Code\":\"A1010\",\"Unit\":\"B/90\",\"Description\":\"Pain reliever and anti-inflammatory medication.\",\"ExpiredAt\":\"2026-06-04T11:07:51.753Z\",\"Stock\":20,\"AvailableStock\":null,\"AlertStock\":18,\"AvrgStock\":13,\"MinStock\":8,\"SafetyStock\":4,\"ReservedStock\":2,\"Price\":5.99,\"Route\":11},\"StartDate\":\"2024-06-15T22:00:00Z\",\"EndDate\":\"2024-06-21T22:00:00Z\",\"IsPermanent\":false,\"Comments\":[{\"Id\":\"85c80596-8d13-4910-afe0-14e9ed311464\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Label\":\"Caution\",\"Content\":\"test caution comment for aspirin  16 - 22\"},{\"Id\":\"126385b0-25de-4f75-ba3d-d5da7b14d5c2\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Label\":\"Comment\",\"Content\":\"test normal comment for aspirin  16 - 22\"}],\"Dispenses\":[{\"Id\":\"97ccd8b2-11bc-4488-8df3-1a02decd9bb5\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":14,\"BeforeMeal\":null,\"AfterMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false}},{\"Id\":\"58f6f2c9-1393-4218-a6ff-48ae0cb19454\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":15,\"BeforeMeal\":{\"Quantity\":6,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"ebb0f79b-0e4f-441c-8ec1-4c4c2e35e7ee\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":12,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"d97579c5-0ec3-4f6a-b8c2-5252f8394ca2\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":0,\"BeforeMeal\":{\"Quantity\":7,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":null},{\"Id\":\"024b4119-ba51-4b45-b60d-8882935d4e30\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":1,\"BeforeMeal\":{\"Quantity\":6,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":{\"Quantity\":3,\"IsValid\":false,\"IsPostValid\":false}},{\"Id\":\"adee02d1-f6fe-445b-b342-b62c7cb46d25\",\"PosologyId\":\"8ec647a6-cf76-4de3-9f40-907d31e097a8\",\"Hour\":2,\"BeforeMeal\":{\"Quantity\":5,\"IsValid\":false,\"IsPostValid\":false},\"AfterMeal\":{\"Quantity\":4,\"IsValid\":false,\"IsPostValid\":false}}]}],\"Symptoms\":[{\"Id\":\"b26b34b6-a5f0-4434-a30e-0408da222d9a\",\"Code\":\"39\",\"Name\":\"Abdominal pain\",\"ShortDescription\":\"Abdominal pain\",\"LongDescription\":\"Abdominal pain\"},{\"Id\":\"c894b12a-68c4-4002-82e0-ebeb03653cac\",\"Code\":\"8\",\"Name\":\"Acidity\",\"ShortDescription\":\"Acidity\",\"LongDescription\":\"Acidity\"}],\"Diagnoses\":[{\"Id\":\"7b647c8f-11eb-4b8d-be4c-209638edbf9a\",\"Code\":\"L70.0\",\"Name\":\"Acne\",\"ShortDescription\":\"Skin condition causing pimples and blackheads\",\"LongDescription\":\"A common skin condition that occurs when hair follicles become clogged with dead skin cells and oil, causing pimples and blackheads\"},{\"Id\":\"b8cb7d46-0548-474b-887f-efeee0e0a350\",\"Code\":\"B24\",\"Name\":\"AIDS\",\"ShortDescription\":\"Acquired immunodeficiency syndrome\",\"LongDescription\":\"An acquired immunodeficiency syndrome caused by the human immunodeficiency virus (HIV), which attacks the body's immune system\"}],\"Diet\":{\"Id\":\"4575e2f6-9ff0-4fe1-a55f-80172c0363e7\",\"StartDate\":\"2024-06-04T23:00:00Z\",\"EndDate\":\"2024-06-15T23:00:00Z\",\"DietsId\":[\"1fabbdfd-8887-4d33-9773-2b2185f6a9e1\"]},\"CreatedAt\":\"2024-06-04T12:10:08.223Z\",\"EventId\":\"89c32f0a-71e4-42a3-81a6-8301489261aa\",\"OccurredOn\":\"2024-06-04T13:12:08.1659795+00:00\",\"EventType\":\"BuildingBlocks.Messaging.Events.PrescriptionEvents.DiscontinuedInpatientPrescriptionSharedEvent, BuildingBlocks.Messaging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\"}\r\n";
    }
}