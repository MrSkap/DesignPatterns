using Domain.Models;

namespace Application.Strategy.Fillers;

/// <summary>
/// Раскладывает товары максимально распределяя вес между хранилищами.
/// </summary>
public class MiddleWeightFiller : IFiller
{
    /// <inheritdoc/>
    public bool FillStorages(List<Storage> storages, List<Good> goods) =>
        //todo: implement filter
        true;
}
