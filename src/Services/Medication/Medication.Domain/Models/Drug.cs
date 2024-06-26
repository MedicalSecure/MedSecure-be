﻿namespace Medication.Domain.Models;

public class Drug : Aggregate<DrugId>
{
    public string Name { get; private set; } = default!;
    public string Dosage { get; private set; } = default!;
    public string Form { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    public string Unit { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public DateTime ExpiredAt { get; private set; } = default!;
    public int Stock { get; private set; } = default!;
    public int AlertStock { get; private set; } = default!;
    public int AvrgStock { get; private set; } = default!;
    public int MinStock { get; private set; } = default!;
    public int SafetyStock { get; private set; } = default!;

    public int AvailableStock
    {
        get => Stock - ReservedStock;
        private set { }
    }

    public int ReservedStock { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    [NotMapped]
    public bool IsDrugExist { get; set; }

    [NotMapped]
    public bool IsDosageValid { get; set; }

    public static Drug Create(
        DrugId id,
        string name,
        string dosage,
        string form,
        string code,
        string unit,
        string description,
        DateTime expiredAt,
        int stock,
        int alertStock,
        int avrgStock,
        int minStock,
        int safetyStock,
        int reservedStock,
        decimal price)
    {
        var drug = new Drug()
        {
            Id = id,
            Name = name,
            Dosage = dosage,
            Form = form,
            Code = code,
            Unit = unit,
            Description = description,
            ExpiredAt = expiredAt,
            Stock = stock,
            AlertStock = alertStock,
            AvrgStock = avrgStock,
            MinStock = minStock,
            SafetyStock = safetyStock,
            ReservedStock = reservedStock,
            Price = price
        };

        drug.AvailableStock = drug.Stock - drug.ReservedStock;

        drug.AddDomainEvent(new DrugCreatedEvent(drug));
        return drug;
    }

    public void ReserveStock(int quantityToReserve)
    {
        if (quantityToReserve < 0)
            throw new DomainException(nameof(ReserveStock) + " : Stock must be greater than 0, error value : " + quantityToReserve);
        if (quantityToReserve > AvailableStock)
            throw new DomainException(nameof(ReserveStock) + $" : Quantity to reserve {quantityToReserve} must be less or equal than {AvailableStock}, Drug id {this.Id.Value}");

        ReservedStock += quantityToReserve;
    }

    public void FreeReservedStock(int quantityToFree)
    {
        if (quantityToFree < 0)
            throw new DomainException(nameof(FreeReservedStock) + " : Stock must be greater than 0, error value : " + quantityToFree);
        if (quantityToFree > ReservedStock)
            throw new DomainException(nameof(FreeReservedStock) + $" : Quantity to free {quantityToFree} must be less or equal than the reserved: {ReservedStock}, Drug id {this.Id.Value}");

        ReservedStock -= quantityToFree;
    }

    public void UpdateStockAfterValidation(int quantityToDeliver)
    {
        if (quantityToDeliver < 0)
            throw new DomainException(nameof(UpdateStockAfterValidation) + " : Quantity must be greater than 0, error value : " + quantityToDeliver);
        if (quantityToDeliver > ReservedStock)
            throw new DomainException(nameof(UpdateStockAfterValidation) + $" : Quantity to deliver {quantityToDeliver} must be less or equal than the reserved: {ReservedStock}, Drug id {this.Id.Value}");

        ReservedStock -= quantityToDeliver;
        Stock -= quantityToDeliver;
    }

    public void UpdateStock(int stock)
    {
        if (stock < 0)
            throw new DomainException(nameof(UpdateStock) + " : Stock must be greater than 0, error value : " + stock);
        Stock = stock;
    }
}