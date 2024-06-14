using Application.Observer.Delegate;
using Domain.Models;
using Serilog;

namespace Application.Observer;

/// <summary>
/// Обслуживает склад.
/// </summary>
public class StorehouseWorker
{
    private ILogger _logger = Log.ForContext<StorehouseWorker>();
    private readonly StorageFiller _storageFiller;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="storageFiller"><see cref="StorageFiller"/>.</param>
    public StorehouseWorker(StorageFiller storageFiller)
    {
        _storageFiller = storageFiller;

        _storageFiller.AllStoragesFullAction = CallForStoragesDelivering;
        storageFiller.FullStoragesObservable.Subscribe(NextStoragePacked);
        storageFiller.AllGoodsPacked += MoveAllGoods; //method for event
    }

    private void MoveAllGoods(object? obj, AllGoodsPackedEventArgs args)
    {

    }

    private void CallForStoragesDelivering()
    {
        _logger.Information("All storages are full, please send me more!!!");
    }

    private void NextStoragePacked(Storage storage)
    {
        _logger.Information("Storage {StorageId} is full, it contains these goods {Goods}", storage.Id, storage.Goods);
    }

}
