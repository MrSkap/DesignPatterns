using Domain.Models;

namespace Application.Strategy.Fillers;

/// <summary>
/// Укладывает товары максимально используя все пространство хранилищ.
/// </summary>
public class MaxVolumeFiller : IFiller
{
    /// <inheritdoc/>
    public bool FillStorages(List<Storage> storages, List<Good> goods) =>
        //todo: implement filter
        true;
}
