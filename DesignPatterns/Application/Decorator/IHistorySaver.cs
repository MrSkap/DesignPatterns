namespace Application.Decorator;

/// <summary>
/// Сохраняет историю доставок.
/// </summary>
public interface IHistorySaver
{
    /// <summary>
    /// Сохранить.
    /// </summary>
    /// <param name="rows">Список <see cref="DeliveryHistoryRow"/>.</param>
    /// <returns><see cref="Task{TResult}"/>.</returns>
    Task Save(List<DeliveryHistoryRow> rows);

    /// <summary>
    /// Сохранить.
    /// </summary>
    /// <param name="row"><see cref="DeliveryHistoryRow"/>.</param>
    /// <returns><see cref="Task{TResult}"/>.</returns>
    Task Save(DeliveryHistoryRow row);
}
