using Application.Strategy.Fillers;

namespace Application.Strategy;

/// <summary>
/// Фабрика заполнителей хранилищ.
/// </summary>
public interface IFillerFactory
{
    /// <summary>
    /// Получить заполнителя.
    /// </summary>
    /// <param name="context"><see cref="FillingContext"/>.</param>
    /// <returns><see cref="IFiller"/>.</returns>
    IFiller GetFiller(FillingContext context);
}
