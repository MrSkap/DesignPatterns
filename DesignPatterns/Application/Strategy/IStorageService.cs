using Application.Strategy.Fillers;
using Domain.Models;

namespace Application.Strategy;

/// <summary>
/// Сервис работы с хранилищами.
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Заполнить хранилища товарами.
    /// </summary>
    /// <param name="storages"><see cref="Storage"/>.</param>
    /// <param name="goods"><see cref="Good"/>.</param>
    /// <param name="type"><see cref="FillingContext"/>.</param>
    void FillStoragesWithProducts(List<Storage> storages, List<Good> goods, FillingContext type);
}
