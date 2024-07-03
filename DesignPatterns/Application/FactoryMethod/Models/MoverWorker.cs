using Domain.Models;
using Serilog;

namespace Application.FactoryMethod.Models;

/// <summary>
/// Перевозчик и грузчик.
/// </summary>
public class MoverWorker : IMover, IWorker
{
    private readonly ILogger _logger = Log.ForContext<MoverWorker>();
    private List<Good>? _goods;

    /// <summary>
    /// Обычный конструктор.
    /// </summary>
    public MoverWorker() { }

    /// <summary>
    /// Конструктор с параметром.
    /// </summary>
    /// <param name="speed">Скорость.</param>
    public MoverWorker(float speed) => Speed = speed;

    /// <summary>
    /// Скорость переноса товаров (вес в секунду).
    /// </summary>
    public float Speed { get; init; } = 1f;

    /// <inheritdoc/>
    public void Move()
    {
        if (_goods == null || _goods.Count == 0)
        {
            _logger.Information("Mover has no goods!");
            return;
        }

        _logger.Information("Move all movers goods {Goods}", _goods);

        //разгрузка товара (используется Speed)
        _goods = new List<Good>();
    }

    /// <inheritdoc/>
    public void Take(IEnumerable<Good> goods) => _goods = goods.ToList();

    /// <inheritdoc/>
    public List<Good>? GetWorkersGoods() => _goods;

    /// <summary>
    /// Статичный фабричный метод создания создания. Нужен, так как конструктор без параметров уже существует.
    /// </summary>
    /// <returns></returns>
    public static MoverWorker FastMoverWorker() => new(10);

    /// <summary>
    /// Статический асинхронный фабричный метод создания. В обычном конструкторе это бы не прокатило.
    /// </summary>
    /// <param name="calculateSpeed"></param>
    /// <returns></returns>
    public static async Task<MoverWorker> CreateMoverWorkerAsync(Func<Task<float>> calculateSpeed)
    {
        var speed = await calculateSpeed();

        return new MoverWorker(speed);
    }
}
