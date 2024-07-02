namespace Application.AbstractFactory.SpecificTransport;

/// <summary>
/// Фура для перевозки по внутренним площадкам склада.
/// </summary>
public class LocalTruck : Truck
{
    /// <inheritdoc/>
    public override void Move(Route route) => throw new NotImplementedException();
}
