using Domain.Models;

namespace Application.Composite;

/// <summary>
/// Фильтр товаров.
/// </summary>
/// <param name="NameFilter">Название.</param>
/// <param name="MaxWeight">Максимальный вес.</param>
/// <param name="MinWeight">Минимальный  вес.</param>
/// <param name="MaxSize">Максимальный размер.</param>
/// <param name="MinSize">Минимальный размер.</param>
/// <param name="Type">Тип.</param>
public record FilterContext(string? NameFilter, float? MaxWeight, float? MinWeight, Size? MaxSize, Size? MinSize, GoodType? Type);
