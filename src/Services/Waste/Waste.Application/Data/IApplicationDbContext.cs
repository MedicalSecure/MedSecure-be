
namespace Waste.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Waste> Wastes { get; }

    DbSet<WasteItem> WasteItems { get; }

    DbSet<Domain.Models.Product> Products { get; }

    DbSet<Domain.Models.Room> Rooms { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
