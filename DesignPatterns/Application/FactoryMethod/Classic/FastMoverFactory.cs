using Application.FactoryMethod.Models;

namespace Application.FactoryMethod.Classic;

/// <summary>
/// Фабрика быстрых грузчиков.
/// </summary>
public class FastMoverFactory : IMoverFactory
{
    /// <inheritdoc/>
    public IMover Create() => new MoverWorker
    {
        Speed = 15,
    };
}
