using Domain.Models;

namespace Application.Builder;

/// <summary>
/// Строитель доставщика.
/// </summary>
public interface IDeliverWorkerBuilder
{
    /// <summary>
    /// Добавить точку назначения.
    /// </summary>
    /// <param name="target"><see cref="Target"/>.</param>
    /// <returns>Строитель.</returns>
    IDeliverWorkerBuilder AddTarget(Target target);

    /// <summary>
    /// Добавить погрузку товара.
    /// </summary>
    /// <param name="goods">Товары.</param>
    /// <returns>Строитель.</returns>
    IDeliverWorkerBuilder AddGoodsLoading(IEnumerable<Good> goods);

    /// <summary>
    /// Добавить разгрузку товара.
    /// </summary>
    /// <param name="goods">Товары.</param>
    /// <returns>Строитель.</returns>
    IDeliverWorkerBuilder AddGoodsUnloading(IEnumerable<Good> goods);

    /// <summary>
    /// Добавить заправку.
    /// </summary>
    /// <returns>Строитель.</returns>
    IDeliverWorkerBuilder AddRefill();

    /// <summary>
    /// Начать строительство.
    /// </summary>
    /// <returns>Строитель.</returns>
    IDeliverWorkerBuilder Build();

    /// <summary>
    /// Создать.
    /// </summary>
    /// <returns>Доставщик.</returns>
    DeliverWorker Create();
}
