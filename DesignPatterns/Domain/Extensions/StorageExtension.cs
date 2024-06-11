using Domain.Models;

namespace Domain.Extensions;

/// <summary>
/// Расширение для <see cref="Storage"/>.
/// </summary>
public static class StorageExtension
{
    /// <summary>
    /// Добавить товар в хранилище.
    /// </summary>
    /// <param name="storage"><see cref="Storage"/>.</param>
    /// <param name="good"><see cref="Good"/>.</param>
    /// <exception cref="ArgumentException">Если товар не влазит, то бросает <see cref="ArgumentException"/>.</exception>
    public static void AddGood(this Storage storage, Good good)
    {
        if (!storage.FreeSize.CanBePlaced(good.Size))
        {
            throw new ArgumentException();
        }

        storage.FreeSize.Width -= good.Size.Width;
        storage.FreeSize.Depth -= good.Size.Depth;
        storage.FreeSize.Height -= good.Size.Height;
        storage.FreeVolume -= good.Size.GetVolume();
        storage.Goods.Add(good);
    }
}
