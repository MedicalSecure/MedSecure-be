using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Exceptions
{
    internal class EquipmentNotFoundException : NotFoundException
    {
        public EquipmentNotFoundException(Guid id) : base("Equipment", id)
        {
        }
    }
}
