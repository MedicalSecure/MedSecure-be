using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.Drugs
{
    public record DrugSharedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Form { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public int? Stock { get; set; }
        public int? AvailableStock { get; set; }
        public int? AlertStock { get; set; }
        public int? AvrgStock { get; set; }
        public int? MinStock { get; set; }
        public int? SafetyStock { get; set; }
        public int? ReservedStock { get; set; }
        public decimal? Price { get; set; }

        // Empty constructor
        public DrugSharedEvent() { }

        // Full constructor
        public DrugSharedEvent(
            Guid id,
            string name,
            string dosage,
            string form,
            string code,
            string unit,
            string? description,
            DateTime? expiredAt,
            int? stock,
            int? availableStock,
            int? alertStock,
            int? avrgStock,
            int? minStock,
            int? safetyStock,
            int? reservedStock,
            decimal? price)
        {
            Id = id;
            Name = name;
            Dosage = dosage;
            Form = form;
            Code = code;
            Unit = unit;
            Description = description;
            ExpiredAt = expiredAt;
            Stock = stock;
            AvailableStock = availableStock;
            AlertStock = alertStock;
            AvrgStock = avrgStock;
            MinStock = minStock;
            SafetyStock = safetyStock;
            ReservedStock = reservedStock;
            Price = price;
        }
    }
}