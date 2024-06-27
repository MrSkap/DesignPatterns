namespace Application.Singleton;

/// <summary>
/// Сервис предоставления настроек работникам. С иницианализацией через DI.
/// </summary>
public interface IWorkerSettingsServiceDefault
{
    /// <summary>
    /// Обозреватель настроек.
    /// </summary>
    public IObservable<Dictionary<string, string>> SettingsObservable { get; }

    /// <summary>
    /// Получить текущие настройки.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> GetCurrentSettings();
}
