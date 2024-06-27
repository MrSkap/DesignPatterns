using Domain.Models;
using Serilog;

namespace Application.Visitor;

/// <inheritdoc/>
public class SupplyService : ISupplyService
{
    private readonly ILogger _logger = Log.ForContext<SupplyService>();
    private readonly StorageFilterOptions _options;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="options"><see cref="StorageFilterOptions"/>.</param>
    public SupplyService(StorageFilterOptions options) => _options = options;

    /// <inheritdoc/>
    public Supply GetStoragesSupply(ProviderBase supplyProvider)
    {
        if (supplyProvider.GetType() != typeof(GoodsSupplyProvider))
        {
            return supplyProvider.Provide();
        }

        var storageSupplyProvider = supplyProvider as StorageSupplyProvider;
        storageSupplyProvider?.SetFilterOptions(_options);
        var res = supplyProvider.Provide();
        _logger.Information("Provide some storages {Storages}", res.Storages);
        return res;
    }

    /// <inheritdoc/>
    public Supply GetGoodsSupply(ProviderBase supplyProvider)
    {
        if (supplyProvider.GetType() != typeof(GoodsSupplyProvider))
        {
            return supplyProvider.Provide();
        }

        var goodSupplyProvider = supplyProvider as GoodsSupplyProvider;
        var provided = goodSupplyProvider?.Provide();
        _logger.Information("Provide some goods {Goods}", provided?.Goods);

        var wrongGoods = new List<Good>();
        var resultedSupply = FilterNonNoneTypedGoods(provided, wrongGoods);

        if (wrongGoods.Count == 0) return resultedSupply;

        _logger.Information("After filtering some wrong goods were found {Goods}", wrongGoods);
        goodSupplyProvider?.GetBackGoods(wrongGoods);
        goodSupplyProvider?.SendAllGoodsBack();

        return resultedSupply;
    }

    /// <inheritdoc/>
    public Supply GetDefaultSupply(ProviderBase supplyProvider)
    {
        var supply = supplyProvider.Provide();
        var filteredSupply = new Supply
        {
            Storages = supply.Storages.Where(x => x.FreeVolume > 0).ToList(),
            Goods = supply.Goods.Where(x => x.Type != GoodType.None).ToList(),
        };
        return filteredSupply;
    }

    private static Supply FilterNonNoneTypedGoods(Supply? fullSupply, List<Good>? wrongGoods)
    {
        wrongGoods ??= new List<Good>();

        if (fullSupply == null)
        {
            return new Supply();
        }

        var filteredSupply = new Supply
        {
            Storages = fullSupply.Storages.Select(x => x).ToList() ?? new List<Storage>(),
        };

        wrongGoods = fullSupply.Goods.Where(x => x.Type == GoodType.None).ToList();
        filteredSupply.Goods = fullSupply.Goods.Where(x => !wrongGoods.Contains(x)).ToList();

        return filteredSupply;
    }
}
