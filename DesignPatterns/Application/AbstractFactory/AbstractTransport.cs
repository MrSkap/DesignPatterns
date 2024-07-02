using Domain.Models;

namespace Application.AbstractFactory;

/// <summary>
/// Транспорт.
/// </summary>
public abstract class AbstractTransport
{
    /// <summary>
    /// Дефолтный маршрут.
    /// </summary>
    protected readonly Route? DefaultRoute;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="defaultRoute"><see cref="Route"/>.</param>
    public AbstractTransport(Route? defaultRoute) => DefaultRoute = defaultRoute;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public AbstractTransport()
    {
    }

    /// <summary>
    /// Максимальный перевозимый вес.
    /// </summary>
    public abstract float MaxWeightOfGoods { get; set; }

    /// <summary>
    /// Загрузить товар.
    /// </summary>
    /// <param name="goods">Товары <see cref="!:Good"/>.</param>
    /// <returns>true - успешно загрузили.</returns>
    public abstract bool TryToPutGoods(IEnumerable<Good> goods);

    /// <summary>
    /// Отправиться.
    /// </summary>
    public abstract void Move(Route route);
}
