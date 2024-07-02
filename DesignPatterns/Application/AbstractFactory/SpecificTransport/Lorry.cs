using Domain.Models;

namespace Application.AbstractFactory.SpecificTransport;

/// <summary>
/// Грузовик.
/// </summary>
public abstract class Lorry : AbstractTransport
{
    /// <inheritdoc/>
    protected Lorry(Route? defaultRoute)
        : base(defaultRoute)
    {
    }

    /// <inheritdoc/>
    public override float MaxWeightOfGoods { get; set; } = 1000;

    /// <inheritdoc/>
    public override bool TryToPutGoods(IEnumerable<Good> goods) => throw new NotImplementedException();
}
