using System.Reactive.Linq;

namespace Application.Singleton;

/// <summary>
/// Сервис предоставления настроек работникам. С использованием <see cref="Lazy{T}"/>.
/// </summary>
public class WorkerSettingsService
{
    private static readonly Lazy<WorkerSettingsService> instance = new(() => new WorkerSettingsService());

    /// <summary>
    /// Обозреватель настроек.
    /// </summary>
    public readonly IObservable<Dictionary<string, string>> SettingsObservable;

    private WorkerSettingsService() =>
        SettingsObservable = Observable.Interval(TimeSpan.FromMinutes(5))
            .StartWith(0)
            .Select(x => ReadSettings());

    /// <summary>
    /// Создать.
    /// </summary>
    public static WorkerSettingsService Instance => instance.Value;

    /// <summary>
    /// Получить текущие настройки.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetCurrentSettings() => new Dictionary<string, string>();

    private Dictionary<string, string> ReadSettings()
    {
        //read settings
        return new Dictionary<string, string>();
    }
}
