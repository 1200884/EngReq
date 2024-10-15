using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Hapibee.Backend.Application.Domain;
using Hapibee.Backend.Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Hapibee.Backend.Application.Infra.Data
{
    internal class HapibeeDbContext : DbContext, IUnitOfWork
    {
        public HapibeeDbContext(DbContextOptions<HapibeeDbContext> options)
            : base(options)
        {
        }
        public DbSet<Inspection> Inspections { get; set; }    
        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Hive> Hives { get; set; }
        public DbSet<Request> Requests { get; set; }

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