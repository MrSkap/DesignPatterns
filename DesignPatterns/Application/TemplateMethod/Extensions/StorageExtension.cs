using Domain.Models;

namespace Application.TemplateMethod.Extensions;

/// <summary>
/// Расширение для <see cref="Storage"/>.
/// </summary>
public static class StorageExtension
{
    /// <summary>
    /// Перенести товары в текущее хранилище из указанного. Освобождает указанное хранилище.
    /// </summary>
    /// <param name="currentStorage">Хранилище.</param>
    /// <param name="storage">Хранилище, от куда перенесутся товары.</param>
    /// <returns><see cref="Storage"/>.</returns>
    public static Storage MoveGoodsFrom(this Storage currentStorage, Storage storage)
    {
        currentStorage.Goods = storage.Goods.Select(x => x).ToList();
        storage.Goods = new List<Good>();
        return currentStorage;
    }
}
