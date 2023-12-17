using BaltaDesafioBlazor.Domain.Handlers.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BaltaDesafioBlazor.Domain.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddTransient<LocalityHandler>();
    }
}
