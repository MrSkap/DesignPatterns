using Domain.Models;

namespace Application.Composite;

/// <summary>
/// Классификатор объектов.
/// </summary>
public interface IGoodFilter
{
    /// <summary>
    /// Фильтровать.
    /// </summary>
    /// <param name="goods">Товары.</param>
    /// <param name="context">Контекст фильтрации.</param>
    /// <returns>Отфильтрованные товары.</returns>
    List<Good> Filter(List<Good> goods, FilterContext context);
}
