using System.Reactive.Linq;
using Application.Mediator;
using Application.Mediator.Context;
using Domain.Models;

namespace Application.Iterator;

/// <summary>
/// Предоставляет поступающие товары.
/// </summary>
public class ObservableGoods
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="provider"></param>
    public ObservableGoods(IGoodsProvider provider) =>
        GoodsObservable = Observable
            .Interval(TimeSpan.FromSeconds(5))
            .Select(x => provider.GetGoods(new GoodsFilterContext
            {
                Count = 1,
            }))
            .Select(x => x.First());

    /// <summary>
    /// Поступающие товары.
    /// </summary>
    public IObservable<Good> GoodsObservable { get; }
}
