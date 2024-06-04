using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCare.Application.Exceptions
{
    internal class RoomNotFoundException : NotFoundException
    {
        public RoomNotFoundException(Guid id) : base("Room", id)
        {
        }
    }
}
