using Hapibee.Backend.Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hapibee.Backend.Application.Infra.Data
{
    public static class DbContextInstaller
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<HapibeeDbContext>(opt =>
                    opt.UseInMemoryDatabase("database"))
                .AddScoped<IUnitOfWork>(sp => sp.GetService<HapibeeDbContext>());
        }
    }
}