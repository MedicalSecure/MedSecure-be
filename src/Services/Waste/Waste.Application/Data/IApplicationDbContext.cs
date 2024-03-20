
namespace Waste.Application.Data;

public interface IApplicationDbContext
{
    DbSet<Domain.Models.Waste> Wastes { get; }

    DbSet<WasteItem> WasteItems { get; }

    DbSet<Product> Products { get; }

    DbSet<Room> Rooms { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
