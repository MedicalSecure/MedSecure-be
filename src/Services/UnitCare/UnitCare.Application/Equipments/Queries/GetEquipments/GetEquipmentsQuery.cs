using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Equipments.Queries.GetEquipments;


public record GetEquipmentsQuery(PaginationRequest PaginationRequest)
: IQuery<GetEquipmentsResult>;

public record GetEquipmentsResult(PaginatedResult<EquipmentDto> Equipments);
