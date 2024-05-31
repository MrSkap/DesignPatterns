using Application.Mediator.Context;
using Application.Strategy;
using Domain.Models;

namespace Application.Mediator;

/// <summary>
/// Упаковывает товары в хранилища.
/// </summary>
public class GoodsPacker
{
    private readonly GoodsGenerator _goodsGenerator;
    private readonly StorageGenerator _storageGenerator;
    private readonly IStorageService _storageService;
    private Queue<Storage> _packedStorages = new Queue<Storage>();
    private Queue<Good> _unpackedGoods = new Queue<Good>();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="goodsGenerator"></param>
    /// <param name="storageGenerator"></param>
    /// <param name="storageService"></param>
    public GoodsPacker(GoodsGenerator goodsGenerator, StorageGenerator storageGenerator, IStorageService storageService)
    {
        _goodsGenerator = goodsGenerator;
        _storageGenerator = storageGenerator;
        _storageService = storageService;
    }

    /// <summary>
    /// Упоковать доступные товары.
    /// </summary>
    public IEnumerable<Storage> Pack()
    {
        var newGoods = GetNewGoods();
        var newStorages = GetNewStorages();

        AddToQueues(newGoods, newStorages);

        return PackGoods();
    }

    private void AddToQueues(IEnumerable<Good> newGoods, IEnumerable<Storage> newStorages)
    {
        foreach (var good in newGoods)
        {
            _unpackedGoods.Enqueue(good);
        }

        foreach (var storage in newStorages)
        {
            _packedStorages.Enqueue(storage);
        }
    }

    private IEnumerable<Storage> GetNewStorages()
    {
        var newStorages = _storageGenerator.GetStorages(new StoragesFilterContext()
        {
            Count = 10,
            MaxSize = new Size()
            {
                Depth = 10,
                Height = 5,
                Width = 5,
            },
            MinSize = new Size()
            {
                Depth = 1,
                Height = 1,
                Width = 1,
            },
        });
        return newStorages;
    }

    private IEnumerable<Good> GetNewGoods()
    {
        var newGoods = _goodsGenerator.GetGoods(new GoodsFilterContext()
        {
            MaxWeight = 1,
            MinWeight = 0.1f,
            Count = 10,
            MinSize = new Size()
            {
                Depth = 0.1f,
                Height = 0.1f,
                Width = 0.1f,
            },
            MaxSize = new Size()
            {
                Depth = 1,
                Height = 1,
                Width = 1,
            },
        });
        return newGoods;
    }

    private IEnumerable<Storage> PackGoods()
    {
        //Packing process
        return new List<Storage>();
    }
}
