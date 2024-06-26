﻿namespace Medication.Infrastructure.Database.Extensions;


internal class InitialData
{
    private static readonly string drugId = "7506213d-3b5f-4498-b35c-9169a600ff00";

    private static readonly string dosageId = "7506213d-3b5f-4498-b35c-9169a600ff11";

    /// <summary>
    /// Retrieves a collection of drugs with their details.
    /// </summary>
    public static IEnumerable<Drug> Drugs
    {
        get
        {
            try
            {
            // Create a list to hold the drugs
            var drugs = new List<Drug>
                {
                    // Create drug instances
                    Drug.Create(
                        id: DrugId.Of(Guid.Parse(drugId)),
                        name: "Aspirin",
                        dosage: "500 mg",
                        form: "Tablet",
                        code: "A1010",
                        unit: "B/90",
                        description: "Pain reliever and anti-inflammatory medication.",
                        expiredAt: DateTime.Now.AddYears(2),
                        stock: 102,
                        alertStock: 18,
                        avrgStock: 13,
                        minStock: 8,
                        safetyStock: 4,
                        reservedStock: 2,
                        price: 5.99m
                    ),

                    Drug.Create(
                        id: DrugId.Of(Guid.NewGuid()),
                        name: "Ibuprofen",
                        dosage: "700 mg",
                        form: "Tablet",
                        code: "A2020",
                        unit: "B/90/5L",
                        description: "Nonsteroidal anti-inflammatory drug (NSAID).",
                        expiredAt: DateTime.Now.AddYears(3),
                        stock: 20,
                        alertStock: 15,
                        avrgStock: 10,
                        minStock: 7,
                        safetyStock: 3,
                        reservedStock: 1,
                        price: 6.99m
                    ),
                    Drug.Create(
                        id: DrugId.Of(Guid.NewGuid()),
                        name: "Fervex",
                        dosage: "1000 mg",
                        form: "Tablet",
                        code: "A2020",
                        unit: "B/90/2L",
                        description: "blalbaalblaalbaablblablabalba.",
                        expiredAt: DateTime.Now.AddYears(3),
                        stock: 30,
                        alertStock: 25,
                        avrgStock: 12,
                        minStock: 9,
                        safetyStock: 2,
                        reservedStock: 5,
                        price: 6.99m
                    ),
                    Drug.Create(
                        id: DrugId.Of(Guid.NewGuid()),
                        name: "Paracetamol",
                        dosage: "250 mg",
                        form: "Tablet",
                        code: "A2020",
                        unit: "mg",
                        description: "Nonsteroidal anti-inflammatory drug (NSAID).",
                        expiredAt: DateTime.Now.AddYears(3),
                        stock: 20,
                        alertStock: 15,
                        avrgStock: 10,
                        minStock: 7,
                        safetyStock: 3,
                        reservedStock: 1,
                        price: 6.99m
                    )
                };

                // Return the list of drugs
                return drugs;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Drug), ex.Message);
            }
        }
    }

    /// <summary>
    /// Retrieves a collection of dosages with their details.
    /// </summary>
    public static IEnumerable<Dosage> Dosages
    {
        get
        {
            try
            {
                // Create a list to hold the dosages
                var dosages = new List<Dosage>
                {
                    // Create dosage instances
                    Dosage.Create(
                        id: DosageId.Of(Guid.NewGuid()),
                        code: "mg",
                        label:"aaaaa"
                    ),

                    Dosage.Create(
                        id: DosageId.Of(Guid.NewGuid()),
                        code: "ml",
                        label:"zzzzz"
                    ),
                    Dosage.Create(
                        id: DosageId.Of(Guid.NewGuid()),
                        code: "mg(mg/ml)",
                        label:"hahahah"
                    ),
                    Dosage.Create(
                        id: DosageId.Of(Guid.NewGuid()),
                        code: "mg/ml",
                        label:"hahahah"
                    ),
                    Dosage.Create(
                        id: DosageId.Of(Guid.NewGuid()),
                        code: "MG",
                        label:"hahahah"
                    ),
                };

                // Return the list of dosages
                return dosages;
            }
            catch (Exception ex)
            {
                throw new EntityCreationException(nameof(Dosage), ex.Message);
            }
        }
    }
}

