using Domain.Models;

namespace Application.Strategy.Fillers;

/// <summary>
/// Заполняет хранилища по типу товаров.
/// </summary>
public class GoodsTypeFiller : IFiller
{
    /// <inheritdoc/>
    public bool FillStorages(List<Storage> storages, List<Good> goods) =>
        //todo: implement filter
        true;
}
