using Sensor.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Domain.Models.Sensor> Sensors => Set<Domain.Models.Sensor>();
    public DbSet<SensorData> SensorData { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
        base.OnModelCreating(modelBuilder);
    }
}

