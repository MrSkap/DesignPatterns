using Domain.Models;

namespace Application.FactoryMethod.Strategy;

/// <summary>
/// Контекст создания грузчиков.
/// </summary>
/// <param name="Speed">Скорость.</param>
/// ///
/// <param name="Goods">Товары.</param>
public sealed record CreateMoverContext(float Speed, List<Good> Goods);
