using Application.Mediator.Context;
using Domain.Models;

namespace Application.Mediator;

/// <summary>
/// Предоставляет товары.
/// </summary>
public interface IGoodsProvider
{
    /// <summary>
    /// Получить.
    /// </summary>
    /// <param name="context"><see cref="GoodsFilterContext"/>.</param>
    /// <returns></returns>
    public IEnumerable<Good> GetGoods(GoodsFilterContext context);
}
