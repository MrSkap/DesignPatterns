using Application.Mediator.Context;
using Domain.Models;

namespace Application.Mediator;

/// <summary>
/// Предоставляет хранилища.
/// </summary>
public interface IStorageProvider
{
    /// <summary>
    /// Получить.
    /// </summary>
    /// <param name="context"><see cref="StoragesFilterContext"/>.</param>
    /// <returns></returns>
    IEnumerable<Storage> GetStorages(StoragesFilterContext context);
}
