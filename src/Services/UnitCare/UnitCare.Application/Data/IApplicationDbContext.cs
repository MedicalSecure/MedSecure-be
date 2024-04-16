using Microsoft.EntityFrameworkCore;
using UnitCare.Domain.Models;

namespace UnitCare.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Domain.Models.UnitCare> UnitCares { get; }

    DbSet<Room> Rooms { get; }

    DbSet<Equipment> Equipments { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
