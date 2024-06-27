using System.Reactive.Linq;

namespace Application.Singleton;

/// <summary>
/// Сервис предоставления настроек работникам. С иницианализацией через DI.
/// </summary>
public class WorkerSettingsServiceDefault : IWorkerSettingsServiceDefault
{
    private WorkerSettingsServiceDefault() =>
        SettingsObservable = Observable.Interval(TimeSpan.FromMinutes(5))
            .StartWith(0)
            .Select(x => ReadSettings());

    /// <inheritdoc/>
    public IObservable<Dictionary<string, string>> SettingsObservable { get; }

    /// <inheritdoc/>
    public Dictionary<string, string> GetCurrentSettings() => new();

    private Dictionary<string, string> ReadSettings() =>
        //read settings
        new();
}
