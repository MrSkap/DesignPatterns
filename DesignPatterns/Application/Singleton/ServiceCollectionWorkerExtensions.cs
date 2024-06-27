using Microsoft.Extensions.DependencyInjection;

namespace Application.Singleton;

/// <summary>
/// Расширение для дообавления сервисов.
/// </summary>
public static class ServiceCollectionWorkerExtensions
{
    /// <summary>
    /// Добавить работников.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <returns></returns>
    public static IServiceCollection AddWorkerSettings(this IServiceCollection services)
    {
        services.AddSingleton<IWorkerSettingsServiceDefault, WorkerSettingsServiceDefault>();
        return services;
    }
}
