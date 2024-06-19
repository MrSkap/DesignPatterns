using Domain.Models;

namespace Application.Visitor;

/// <summary>
/// Посетитель поставщиков.
/// </summary>
public interface ISupplyService
{
    /// <summary>
    /// Получить только отфильтрованные хранилища.
    /// </summary>
    /// <param name="supplyProvider"><see cref="ProviderBase"/>.</param>
    Supply GetStoragesSupply(ProviderBase supplyProvider);

    /// <summary>
    /// Получить только отфильтрованные товары.
    /// </summary>
    /// <param name="supplyProvider"><see cref="ProviderBase"/>.</param>
    Supply GetGoodsSupply(ProviderBase supplyProvider);

    /// <summary>
    /// Посетить.
    /// </summary>
    /// <param name="supplyProvider"><see cref="ProviderBase"/>.</param>
    Supply GetDefaultSupply(ProviderBase supplyProvider);
}
