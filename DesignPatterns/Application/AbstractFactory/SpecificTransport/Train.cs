using Domain.Models;

namespace Application.AbstractFactory.SpecificTransport;

/// <summary>
/// Поезд.
/// </summary>
public abstract class Train : AbstractTransport
{
    /// <inheritdoc/>
    public override float MaxWeightOfGoods { get; set; } = 100_000f;

    /// <inheritdoc/>
    public override bool TryToPutGoods(IEnumerable<Good> goods) => throw new NotImplementedException();
}
