using Domain.Models;

namespace Application.Composite;

/// <summary>
/// Правильно фильтрации.
/// </summary>
public class Rule
{
    private readonly List<Rule>? _rules;

    public Rule(List<Rule>? rules = null) => _rules = rules;

    public virtual List<Good> Filter(List<Good> goods, FilterContext context)
    {
        var filteredGoods = new List<Good>();
        if (_rules == null)
        {
            return goods;
        }

        foreach (var rule in _rules)
        {
            filteredGoods.AddRange(rule.Filter(goods, context));
        }

        return filteredGoods;
    }
}
