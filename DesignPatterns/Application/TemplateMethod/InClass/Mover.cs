using Domain.Models;
using Serilog;

namespace Application.TemplateMethod.InClass;

/// <summary>
/// Переносит товары.
/// </summary>
public class Mover
{
    private readonly ILogger _logger = Log.ForContext<Mover>();

    /// <summary>
    /// Переместить все товары с указанным типами.
    /// </summary>
    /// <param name="from">Из.</param>
    /// <param name="to">В.</param>
    /// <param name="types"><see cref="GoodType"/>.</param>
    public void MoveAllWithTypes(Storage from, Storage to, List<GoodType> types) =>
        Move(from, to, () => from.Goods.Where(x => types.Contains(x.Type)).ToList());

    /// <summary>
    /// Переместить все товары с указанным типом.
    /// </summary>
    /// <param name="from">Из.</param>
    /// <param name="to">В.</param>
    /// <param name="type"><see cref="GoodType"/>.</param>
    public void MoveAllWithType(Storage from, Storage to, GoodType type)
    {
        _logger.Information("Select {Type} from {From} and move to {To} storage",type,from.Id, to.Id);
        Move(from, to, () => from.Goods.Where(x => x.Type == type).ToList());
    }

    private void Move(Storage from, Storage to, Func<List<Good>> selector)
    {
        to.Goods = selector();
        from.Goods.RemoveAll(x => to.Goods.Contains(x));
    }
}
