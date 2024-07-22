using Domain.Models;

namespace Application.Proxy;

/// <summary>
/// Доставщик.
/// </summary>
public interface IPostman
{
    /// <summary>
    /// Доставить указанные посылки.
    /// </summary>
    /// <param name="packages"></param>
    void DeliverPackages(IEnumerable<Package> packages);

    /// <summary>
    /// Получить состояние доставщика.
    /// </summary>
    /// <returns>Состояние.</returns>
    Task<PostmanState> GetStateAsync();
}
