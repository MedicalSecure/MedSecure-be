using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Domain.Abstractions.Repositories
{
    internal interface IUnitCareRepository
    {
        Task<UnitCare> GetUnitCareByBedId(int id);
    }
}