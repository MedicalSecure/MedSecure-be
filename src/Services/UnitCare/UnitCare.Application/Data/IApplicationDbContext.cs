using Microsoft.EntityFrameworkCore;
using UnitCare.Domain.Models;

namespace UnitCare.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Domain.Models.UnitCare> UnitCares { get; }

    DbSet<Room> Rooms { get; }

    DbSet<Equipment> Equipments { get; }

    public DbSet<Domain.Models.Activity> Activities { get; }

    DbSet<Domain.Models.Task> Tasks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
