namespace Application.AbstractFactory.SpecificTransport;

/// <summary>
/// Грузовик дл развоза товаров по городу.
/// </summary>
public class CityLorry : Lorry
{
    /// <inheritdoc/>
    public CityLorry(Route? defaultRoute)
        : base(defaultRoute)
    {
    }

    //развозит товары по ПВЗ и клиентам.
    /// <inheritdoc/>
    public override void Move(Route route) => throw new NotImplementedException();
}
