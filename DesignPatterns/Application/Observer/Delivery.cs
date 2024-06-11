using Application.Observer.Delegate;
using Domain.Models;

namespace Application.Observer;

/// <summary>
/// Доставка.
/// </summary>
public class Delivery
{
    private readonly StorageFiller _filler;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="filler"><see cref="StorageFiller"/>.</param>
    public Delivery(StorageFiller filler)
    {
        _filler = filler;
    }

    /// <summary>
    /// Доставить хранилища до склада.
    /// </summary>
    public void DeliverStorages()
    {
        //получение колекции хранилищ

        _filler.AddStoragesForFilling(new List<Storage>());
    }

    /// <summary>
    /// Доставить товары.
    /// </summary>
    public void DeliverGoods()
    {
        //получение товаров

        _filler.AddGoodsForPacking(new List<Good>());
    }
}
