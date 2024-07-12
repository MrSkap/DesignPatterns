using Domain.Models;

namespace Application.Facade;

/// <summary>
/// Полылка.
/// </summary>
/// <param name="Goods">Товары.</param>
/// <param name="Id">Идентификатор посылки.</param>
public sealed record Package(List<Good> Goods, Guid Id);
