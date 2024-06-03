using Domain.Models;
using Serilog;

namespace Application.Iterator;

/// <summary>
/// Следит за полученными товарами.
/// </summary>
public class GoodsObserver
{
    private readonly ILogger _logger = Log.ForContext<GoodsObserver>();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="observableGoods"></param>
    public GoodsObserver(ObservableGoods observableGoods) =>
        observableGoods.GoodsObservable.Subscribe(
            OnNewGood,
            OnComplete);

    private void OnNewGood(Good good) => _logger.Information("Have new good: {Good}", good);

    private void OnComplete() => _logger.Information("Stop goods processing");
}
