using Domain.Models;

namespace Application.Mediator.Context;

/// <summary>
/// Контекст фильтрации хранилищ.
/// </summary>
public class StoragesFilterContext
{
    /// <summary>
    /// Количество.
    /// </summary>
    public int Count { get; init; } = 10;

    /// <summary>
    /// Максимальный размер (по каждой характеристике).
    /// </summary>
    public Size? MaxSize { get; init; }

    /// <summary>
    /// Минимальный размер (по каждой характеристике).
    /// </summary>
    public Size? MinSize { get; init; }
}
