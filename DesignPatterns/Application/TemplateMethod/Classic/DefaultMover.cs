using Domain.Models;
using Serilog;

namespace Application.TemplateMethod.Classic;

/// <summary>
/// Переносит товары.
/// </summary>
public abstract class DefaultMover
{
    private readonly ILogger _logger = Log.ForContext<DefaultMover>();

    /// <summary>
    /// Перенести товары из одного хранилища в другой.
    /// </summary>
    /// <param name="from">От куда переносится.</param>
    /// <param name="to">Куда переносится.</param>
    public void MoveGoods(Storage from, Storage to)
    {
        _logger.Information("-> Move goods from {From} to {To}", from.Id, to.Id);
        Move(from, to);
        _logger.Information("<- Move goods from {From} to {To}", from.Id, to.Id);
    }

    /// <summary>
    /// Перенести.
    /// </summary>
    /// <param name="from">Из.</param>
    /// <param name="to">В.</param>
    protected abstract void Move(Storage from, Storage to);
}
