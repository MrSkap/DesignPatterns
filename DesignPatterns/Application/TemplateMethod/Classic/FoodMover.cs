using Domain.Models;
using Serilog;

namespace Application.TemplateMethod.Classic;

/// <summary>
/// Переносит еду.
/// </summary>
public class FoodMover: DefaultMover
{
    private readonly ILogger _logger = Log.ForContext<FoodMover>();

    /// <inheritdoc />
    protected override void Move(Storage from, Storage to)
    {
        _logger.Information("Select food from {From} and move to {To} storage", from.Id, to.Id);
        to.Goods = from.Goods.Where(x => x.Type == GoodType.Food).ToList();
        from.Goods.RemoveAll(x => to.Goods.Contains(x));
    }
}
