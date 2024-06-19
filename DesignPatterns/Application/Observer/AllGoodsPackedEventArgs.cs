using Domain.Models;

namespace Application.Observer;

/// <summary>
/// Аргументы события уполковки всех товаров.
/// </summary>
public class AllGoodsPackedEventArgs : EventArgs
{
    /// <summary>
    /// Упакованные хранилища.
    /// </summary>
    public IEnumerable<Storage>? PackedStorages;
}
