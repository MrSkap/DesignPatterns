namespace Application.Composite;

/// <summary>
/// Создатель правил.
/// </summary>
public class RuleBuilder
{
    /// <summary>
    /// Создать.
    /// </summary>
    /// <returns>Правило.</returns>
    public static Rule Create() =>
        new(new List<Rule>
        {
            new TypeFilter(),
            new(new List<Rule>
            {
                new WeightRule(),
            }),
        });
}
