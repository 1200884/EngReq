using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Hapibee.Backend.Application.Domain.Flights;
using Hapibee.Backend.Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Hapibee.Backend.Domain.Data
{
    internal class FlightsDbContext : DbContext, IUnitOfWork
    {
        public FlightsDbContext(DbContextOptions<FlightsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }


        public Task Save(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            }
        }
    }
}