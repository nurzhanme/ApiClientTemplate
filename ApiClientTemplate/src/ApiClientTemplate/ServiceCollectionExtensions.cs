using ApiClientTemplate.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiClientTemplate;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiClientTemplateClient(this IServiceCollection services)
    {
        services.AddOptions<ApiClientTemplateOptions>();
        AddHttpClientWithHandlers(services);
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        services.Configure<ApiClientTemplateOptions>(configuration.GetSection(nameof(ApiClientTemplateOptions)));
        return services;
    }

    public static IServiceCollection AddApiClientTemplateClient(this IServiceCollection services, Action<ApiClientTemplateOptions> setupAction)
    {
        services.AddOptions<ApiClientTemplateOptions>().Configure(setupAction);
        AddHttpClientWithHandlers(services);
        return services;
    }

    private static void AddHttpClientWithHandlers(IServiceCollection services)
    {
        services
            .AddScoped<LoggingHandler>()
            .AddScoped<ExceptionHandler>();

        services
            .AddHttpClient<ApiClientTemplateClient>()
            .AddHttpMessageHandler<LoggingHandler>()
            .AddHttpMessageHandler<ExceptionHandler>();
    }
}