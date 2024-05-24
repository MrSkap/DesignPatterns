using Application.Strategy.Fillers;
using Domain.Models;

namespace Application.Strategy;

/// <inheritdoc/>
public class StorageService : IStorageService
{
    private readonly IFillerFactory _fillerFactory;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="fillerFactory"><see cref="IFillerFactory"/>.</param>
    public StorageService(IFillerFactory fillerFactory) => _fillerFactory = fillerFactory;

    /// <inheritdoc/>
    public void FillStoragesWithProducts(List<Storage> storages, List<Good> goods, FillingContext type) =>
        _fillerFactory.GetFiller(type).FillStorages(storages, goods);
}
