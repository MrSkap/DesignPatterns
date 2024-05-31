using Application.Mediator;
using Application.Mediator.Context;
using Domain.Models;

namespace Application.Iterator;

/// <summary>
/// Создает товары.
/// </summary>
public class GoodsCreator
{
    private readonly IGoodsProvider _provider;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="provider"></param>
    public GoodsCreator(IGoodsProvider provider) => _provider = provider;

    /// <summary>
    /// Создать.
    /// </summary>
    /// <param name="count">Количество.</param>
    /// <returns></returns>
    public IEnumerable<Good> GetGoods(int count)
    {
        var createdCount = 0;
        while (createdCount < count)
        {
            createdCount++;
            var good = CreateGood();
            yield return good;
        }
    }

    private Good CreateGood() =>
        _provider.GetGoods(new GoodsFilterContext
        {
            MaxWeight = 10,
            MinWeight = 0.1f,
        }).First();
}
