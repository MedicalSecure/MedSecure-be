using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorData.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SensorData> SensorData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionString");
        }
    }

}
