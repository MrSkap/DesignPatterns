using Application.AbstractFactory.SpecificTransport;

namespace Application.AbstractFactory.Transport;

/// <summary>
/// Грузовик для перемещения товаров по складской территории.
/// </summary>
public sealed class LocalLorry : Lorry
{
    /// <inheritdoc/>
    public LocalLorry(Route? defaultRoute)
        : base(defaultRoute)
    {
    }

    //Развозит товары по складам
    /// <inheritdoc/>
    public override void Move(Route route) => throw new NotImplementedException();
}
