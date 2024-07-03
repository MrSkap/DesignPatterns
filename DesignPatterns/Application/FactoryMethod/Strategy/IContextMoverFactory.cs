using Application.FactoryMethod.Models;

namespace Application.FactoryMethod.Strategy;

/// <summary>
/// Полиморфный фабричный метод.
/// </summary>
public interface IContextMoverFactory
{
    /// <summary>
    /// Создать.
    /// </summary>
    /// <param name="context">Контекст.</param>
    /// <returns><see cref="IMover"/>.</returns>
    IMover Create(CreateMoverContext context);
}
