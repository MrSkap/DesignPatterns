using Domain.Models;

namespace Application.Composite;

/// <summary>
/// Фильтр товаров.
/// </summary>
public class GoodFilter : IGoodFilter
{
    private readonly FilterContext _context;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="context">Контекст фильтрации.</param>
    public GoodFilter(FilterContext context) => _context = context;

    /// <inheritdoc/>
    public List<Good> Filter(List<Good> goods, FilterContext context)
    {
        var headRule = RuleBuilder.Create();
        return headRule.Filter(goods, context);
    }
}
