using Domain.Models;
using Serilog;

namespace Application.ChainOfResponsibility;

/// <summary>
/// Обработчик техники.
/// </summary>
public class TechHandler : GoodsHandler
{
    private readonly ILogger _logger = Log.ForContext<TechHandler>();

    /// <inheritdoc />
    public override void Handle(Good good)
    {
        if (good.Type == GoodType.Tech)
        {
            _logger.Information("Found technique {Technique}!", good);
            return;
        }

        NextHandler?.Handle(good);
    }
}
