using Application.AbstractFactory.Transport;

namespace Application.AbstractFactory;

/// <inheritdoc/>
public class LocalTransportFactory : ITransportFactory
{
    /// <inheritdoc/>
    public AbstractTransport CreateTransport() => new LocalLorry(new Route());
}
