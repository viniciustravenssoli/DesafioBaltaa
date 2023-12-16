using BaltaDesafioBlazor.Domain.Repositories;
using BaltaDesafioBlazor.Infra.Data;
using BaltaDesafioBlazor.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BaltaDesafioBlazor.Infra.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddDbContextFactory<DataContext>()
            .AddTransient<ILocalityRepository, LocalityRepository>();
    }
}
