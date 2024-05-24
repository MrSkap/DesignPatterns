using Domain.Models;

namespace Application.Strategy.Fillers;

/// <summary>
/// Заполняет хранилища товарами.
/// </summary>
public interface IFiller
{
    /// <summary>
    /// Заполнить хранилища.
    /// </summary>
    /// <param name="storages"><see cref="Storage"/>.</param>
    /// <param name="goods"><see cref="Good"/>.</param>
    /// <returns>
    /// true - получилось упоковать все товары,
    /// false - не получилось.
    /// </returns>
    bool FillStorages(List<Storage> storages, List<Good> goods);
}
