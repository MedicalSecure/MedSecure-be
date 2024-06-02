using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCare.Application.Dtos;

namespace UnitCare.Application.Equipments.Queries.GetEquipmentByNameQuery
{
  
    public record GetEquipmentByNameQuery(string name) : IQuery<GetEquipmentByNameResult>;

    public record GetEquipmentByNameResult(IEnumerable<EquipmentDto> Equipments);
}
