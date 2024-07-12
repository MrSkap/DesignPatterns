using Domain.Models;

namespace Application.Decorator;

/// <summary>
/// Доставщик.
/// </summary>
public interface IDeliveryman
{
    /// <summary>
    /// Доставить.
    /// </summary>
    /// <param name="package">Посылка.</param>
    /// <param name="address">Адрес.</param>
    /// <returns>Результат доставки.</returns>
    Task<bool> Deliver(Package package, string address);
}
