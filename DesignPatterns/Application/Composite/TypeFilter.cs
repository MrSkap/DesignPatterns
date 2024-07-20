using Domain.Models;

namespace Application.Composite;

/// <inheritdoc/>
public class TypeFilter : Rule
{
    /// <inheritdoc/>
    public TypeFilter(List<Rule>? rules = null)
        : base(rules)
    {
        if (rules != null)
        {
            throw new Exception("This is leaf rule, it can not contain other rules");
        }
    }

    /// <inheritdoc/>
    public override List<Good> Filter(List<Good> goods, FilterContext context) =>
        context.Type == null
            ? goods
            : goods.Where(x => x.Type == context.Type).ToList();
}
