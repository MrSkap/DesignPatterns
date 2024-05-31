using Domain.Models;

namespace Application.Mediator.Context;

/// <summary>
/// Контекст фильтрации товаров.
/// </summary>
public record GoodsFilterContext
{
    /// <summary>
    /// Количество.
    /// </summary>
    public int Count { get; init; } = 10;

    /// <summary>
    /// Тип.
    /// </summary>
    public GoodType? Type { get; init; }

    /// <summary>
    /// Максимальный вес.
    /// </summary>
    public float? MaxWeight { get; init; }

    /// <summary>
    /// Минимальынй вес.
    /// </summary>
    public float? MinWeight { get; init; }

    /// <summary>
    /// Максимальный размер (по каждой характеристике).
    /// </summary>
    public Size? MaxSize { get; init; }

    /// <summary>
    /// Минимальный размер (по каждой характеристике).
    /// </summary>
    public Size? MinSize { get; init; }
}
