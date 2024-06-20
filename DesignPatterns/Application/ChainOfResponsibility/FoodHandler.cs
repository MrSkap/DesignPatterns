using Domain.Models;
using Serilog;

namespace Application.ChainOfResponsibility;

/// <summary>
/// Обработчик еды.
/// </summary>
public class FoodHandler : GoodsHandler
{
    private readonly ILogger _logger = Log.ForContext<FoodHandler>();

    /// <inheritdoc />
    public override void Handle(Good good)
    {
        if (good.Type == GoodType.Food)
        {
            _logger.Information("Found food {Food}!", good);
            return;
        }

        NextHandler?.Handle(good);
    }
}
