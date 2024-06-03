using Application.Mediator;
using Domain.Models;
using System.Reactive.Linq;
using Application.Mediator.Context;

namespace Application.Iterator;

/// <summary>
/// Предоставляет поступающие товары.
/// </summary>
public class ObservableGoods
{
    private IObservable<Good> _goodsObservable;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="provider"></param>
    public ObservableGoods(IGoodsProvider provider)
    {
        _goodsObservable = Observable
            .Interval(TimeSpan.FromSeconds(5))
            .Select(x => provider.GetGoods(new GoodsFilterContext
            {
                Count = 1,
            }))
            .Select(x => x.First());
    }

    /// <summary>
    /// Поступающие товары.
    /// </summary>
    public IObservable<Good> GoodsObservable => _goodsObservable;
}
