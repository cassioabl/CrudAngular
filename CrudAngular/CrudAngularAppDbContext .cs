using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CrudAngular
{
    public class CrudAngularAppDbContext : DbContext
    {
        public CrudAngularAppDbContext(DbContextOptions<CrudAngularAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<PeriodicElement>  PeriodicElements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", false, true)
           .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
