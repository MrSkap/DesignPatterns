using Domain.Models;

namespace Application.Decorator;

/// <summary>
/// Записб в истории доставок.
/// </summary>
public sealed record DeliveryHistoryRow
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Посылка.
    /// </summary>
    public Package? Package { get; init; }

    /// <summary>
    /// Адрес.
    /// </summary>
    public string? Address { get; init; }

    /// <summary>
    /// Результат доставки.
    /// </summary>
    public bool Result { get; init; }
}
