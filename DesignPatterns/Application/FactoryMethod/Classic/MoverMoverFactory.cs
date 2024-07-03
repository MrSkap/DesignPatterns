using Application.FactoryMethod.Models;

namespace Application.FactoryMethod.Classic;

/// <summary>
/// Фабрика грузчиков.
/// </summary>
public class SlowMoverFactory : IMoverFactory
{
    /// <inheritdoc/>
    public IMover Create() => new MoverWorker { Speed = 3f };
}
