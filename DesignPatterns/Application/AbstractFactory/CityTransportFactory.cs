using Application.AbstractFactory.SpecificTransport;

namespace Application.AbstractFactory;

/// <summary>
/// Предоставляет транспорт для перевозки по городу.
/// </summary>
public class CityTransportFactory : ITransportFactory
{
    /// <inheritdoc/>
    public AbstractTransport CreateTransport() => new CityLorry(new Route());
}
