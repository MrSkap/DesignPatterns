namespace Application.Visitor;

/// <summary>
/// Клиент, для использования посетителя.
/// </summary>
public class Client
{
    private readonly GoodsSupplyProvider _goodsSupplyProvider;
    private readonly StorageSupplyProvider _storageSupplyProvider;
    private readonly ISupplyService _supplyService;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="supplyService"></param>
    /// <param name="goodsSupplyProvider"></param>
    /// <param name="storageSupplyProvider"></param>
    public Client(ISupplyService supplyService, GoodsSupplyProvider goodsSupplyProvider, StorageSupplyProvider storageSupplyProvider)
    {
        _supplyService = supplyService;
        _goodsSupplyProvider = goodsSupplyProvider;
        _storageSupplyProvider = storageSupplyProvider;
    }

    /// <summary>
    /// Получить поставки.
    /// </summary>
    public void GetSomeSupply()
    {
        var goodsSupply = _goodsSupplyProvider.ProvideWithFiltering(_supplyService);
        var storagesSupply = _storageSupplyProvider.ProvideWithFiltering(_supplyService);
    }
}
