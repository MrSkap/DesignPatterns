using Domain.Models;
using Serilog;

namespace Application.ChainOfResponsibility;

/// <summary>
/// Обработчик товаров.
/// </summary>
public class GoodsHandler
{
    private readonly ILogger _logger = Log.ForContext<TechHandler>();

    /// <summary>
    /// Следующий обработчик
    /// </summary>
    public GoodsHandler? NextHandler { get; set; }

    /// <summary>
    /// Обработать товар.
    /// </summary>
    /// <param name="good"></param>
    public virtual void Handle(Good good)
    {
        if (good.Type == GoodType.None)
        {
            _logger.Information("Unknown good {Unknown}!", good);
            return;
        }

        NextHandler?.Handle(good);
    }
}
