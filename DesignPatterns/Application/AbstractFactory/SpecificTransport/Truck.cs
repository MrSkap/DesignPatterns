using Domain.Models;

namespace Application.AbstractFactory.SpecificTransport;

/// <summary>
/// Фура.
/// </summary>
public abstract class Truck : AbstractTransport
{
    /// <inheritdoc/>
    public override float MaxWeightOfGoods { get; set; } = 5000f;

    /// <inheritdoc/>
    public override bool TryToPutGoods(IEnumerable<Good> goods) => throw new NotImplementedException();
}
