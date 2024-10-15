using Hapibee.Backend.Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hapibee.Backend.Domain.Data
{
    public static class DbContextInstaller
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<FlightsDbContext>(opt =>
                        opt.UseInMemoryDatabase("database"))
                .AddScoped<IUnitOfWork>(sp => sp.GetService<FlightsDbContext>());
        }
    }
}