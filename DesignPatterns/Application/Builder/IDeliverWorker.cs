namespace Application.Builder;

/// <summary>
/// Доставщик.
/// </summary>
public interface IDeliverWorker
{
    /// <summary>
    /// Начать работать.
    /// </summary>
    /// <returns>Задача.</returns>
    Task StartWorkDay();
}
