using System.Reactive.Subjects;
using Domain.Extensions;
using Domain.Models;

namespace Application.Observer.Delegate;

/// <summary>
/// Заполняет хранилища.
/// Содержит различные варианты уведомлений о заполнении хранилищ и истечении очередей схранилищ на заполнение и товаров на упаковку.
/// </summary>
public class StorageFiller : IDisposable
{
    private readonly Queue<Storage> _storages = new();
    private readonly Queue<Good> _goods = new();
    private readonly CancellationTokenSource _cts = new();
    private readonly Task _fillingTask;
    private Good? _currentGood;
    private Storage? _currentStorage;
    private List<Storage> _packedStorages = new();
    private readonly Subject<Storage> _storagesSubject = new();

    /// <summary>
    /// Действие, вызываемое, когда всех хранилища будут заполнены.
    /// </summary>
    public Action? AllStoragesFullAction;

    /// <summary>
    /// Событие - все товары упакованы.
    /// </summary>
    public event EventHandler<AllGoodsPackedEventArgs>? AllGoodsPacked;

    /// <summary>
    /// Наблюдатель за заполненными хранилищами.
    /// </summary>
    public IObservable<Storage> FullStoragesObservable => _storagesSubject;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public StorageFiller() => _fillingTask = FillingStorages(_cts.Token);

    /// <summary>
    /// Добавить хранилища для заполнения.
    /// </summary>
    /// <param name="storages"></param>
    public void AddStoragesForFilling(IEnumerable<Storage> storages)
    {
        foreach (var storage in storages)
        {
            _storages.Enqueue(storage);
        }
    }

    /// <summary>
    /// Добавить товары для упаковки.
    /// </summary>
    /// <param name="goods"></param>
    public void AddGoodsForPacking(IEnumerable<Good> goods)
    {
        foreach (var good in goods)
        {
            _goods.Enqueue(good);
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _cts.Cancel();
        _fillingTask.Wait();
        _cts.Dispose();
    }

    private async Task FillingStorages(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await Task.Run(FillingIteration, ct);
            if (_currentStorage == null)
            {
                AllStoragesFullAction?.Invoke();
            }

            if (_currentGood == null && AllGoodsPacked != null)
            {
                AllGoodsPacked.Invoke(this,
                    new AllGoodsPackedEventArgs
                    {
                        PackedStorages = _packedStorages,
                    });
                _packedStorages = new List<Storage>();
            }

            await Task.Delay(5000, ct);
        }
    }

    private void FillingIteration()
    {
        if (!_storages.TryDequeue(out var storage))
        {
            _currentStorage = null;
            return;
        }

        while (_currentGood != null && storage.FreeSize.CanBePlaced(_currentGood.Size))
        {
            if (!_goods.TryDequeue(out var nextGood))
            {
                _currentGood = null;
                break;
            }

            storage.AddGood(_currentGood);
            _currentGood = nextGood;
        }

        _packedStorages.Add(storage);
        _storagesSubject.OnNext(storage);
    }

    private void PutGoodInStorage(Good good, Storage storage)
    {
        if (storage.FreeSize.CanBePlaced(good.Size))
        {
            storage.AddGood(good);
        }
    }
}
