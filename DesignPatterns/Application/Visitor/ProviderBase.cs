using Domain.Models;

namespace Application.Visitor;

/// <summary>
/// Базовый класс, предоставления поставок.
/// </summary>
public abstract class ProviderBase
{
    /// <summary>
    /// Принять.
    /// </summary>
    /// <param name="service"></param>
    public virtual Supply ProvideWithFiltering(ISupplyService service) => service.GetDefaultSupply(this);

    /// <summary>
    /// Поставить.
    /// </summary>
    /// <returns><see cref="Supply"/>.</returns>
    public abstract Supply Provide();
}
