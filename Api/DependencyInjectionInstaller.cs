using Hapibee.Backend.Application.Application;
using Hapibee.Backend.Application.Domain;
using Hapibee.Backend.Application.Infra.Data;
using Hapibee.Backend.Application.Infra.Gateway;
using Hapibee.Backend.Application.Properties;
using Microsoft.Extensions.DependencyInjection;

namespace Hapibee.Backend.Api
{
    public static class DependencyInjectionInstaller
    {
        public static IServiceCollection InstallDependencies(this IServiceCollection services)
        {
            return services.AddDbContext()
                .AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(IApplicationAssemblyMarker).Assembly); })
                .AddScoped<IApiaryRepository, ApiaryRepositoryInMemory>()
                .AddScoped<IDgavGateway, DgavGatewayFake>()
                .AddScoped<IManagementEntityOfControlledAreasGateway,
                    ManagementEntityOfControlledAreasGatewayFake>()
                .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}