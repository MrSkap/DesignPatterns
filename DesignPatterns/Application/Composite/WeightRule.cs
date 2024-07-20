using Domain.Models;

namespace Application.Composite;

public class WeightRule : Rule
{
    /// <inheritdoc/>
    public WeightRule(List<Rule>? rules = null)
        : base(rules)
    {
        if (rules != null)
        {
            throw new Exception("This is leaf rule, it can not contain other rules");
        }
    }

    /// <inheritdoc/>
    public override List<Good> Filter(List<Good> goods, FilterContext context)
    {
        if (context.MinWeight == null && context.MaxWeight == null)
        {
            return goods;
        }

        return goods.Where(x =>
            IsMoreOrEqualThan(x.Weight, context.MinWeight)
            && IsLowerOrEqualThan(x.Weight, context.MaxWeight)).ToList();
    }

    private bool IsMoreOrEqualThan(float first, float? second)
    {
        if (second == null)
        {
            return true;
        }

        return first >= second;
    }

    private bool IsLowerOrEqualThan(float first, float? second)
    {
        if (second == null)
        {
            return true;
        }

        return first <= second;
    }
}
