using Domain.Models;

namespace Application.Visitor;

/// <summary>
/// Предоставляет товары.
/// </summary>
public class GoodsSupplyProvider: ProviderBase
{
    private List<Good> _returnedGoods = new List<Good>();

    /// <inheritdoc />
    public override Supply ProvideWithFiltering(ISupplyService service) => service.GetGoodsSupply(this);

    /// <inheritdoc />
    public override Supply Provide()
    {
        return new Supply()
        {
            Goods = new List<Good>()
            {
                new Good()
            }
        };
    }

    /// <summary>
    /// Получить обратно товары.
    /// </summary>
    /// <param name="goods">Товары.</param>
    public void GetBackGoods(IEnumerable<Good> goods)
    {
        foreach (var good in goods)
        {
            _returnedGoods.Add(good);
        }
    }

    /// <summary>
    /// Отправить неподошедшие товары.
    /// </summary>
    public void SendAllGoodsBack()
    {
        // отправка товаров обратно
        _returnedGoods = new List<Good>();
    }
}
