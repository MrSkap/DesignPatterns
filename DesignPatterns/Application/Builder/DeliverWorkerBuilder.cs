using Domain.Models;

namespace Application.Builder;

/// <inheritdoc/>
public class DeliverWorkerBuilder : IDeliverWorkerBuilder
{
    private DeliverWorker _worker;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public DeliverWorkerBuilder() => _worker = new DeliverWorker();

    /// <inheritdoc/>
    public IDeliverWorkerBuilder AddTarget(Target target)
    {
        _worker.Tasks.Enqueue(() => MoveToTargetAsync(target));
        return this;
    }

    /// <inheritdoc/>
    public IDeliverWorkerBuilder AddGoodsLoading(IEnumerable<Good> goods)
    {
        _worker.Tasks.Enqueue(() => LoadGoodsAsync(goods));
        return this;
    }

    /// <inheritdoc/>
    public IDeliverWorkerBuilder AddGoodsUnloading(IEnumerable<Good> goods)
    {
        _worker.Tasks.Enqueue(() => UnloadGoodsAsync(goods));
        return this;
    }

    /// <inheritdoc/>
    public IDeliverWorkerBuilder AddRefill()
    {
        _worker.Tasks.Enqueue(RefillAsync);
        return this;
    }

    /// <inheritdoc/>
    public IDeliverWorkerBuilder Build()
    {
        _worker = new DeliverWorker();
        return this;
    }

    /// <inheritdoc/>
    public DeliverWorker Create() => _worker;

    private Task MoveToTargetAsync(Target target) =>
        //едем к цели
        Task.CompletedTask;

    private Task LoadGoodsAsync(IEnumerable<Good> goods) =>
        //загружаем товары
        Task.CompletedTask;

    private Task UnloadGoodsAsync(IEnumerable<Good> goods) =>
        //разгружаем товары
        Task.CompletedTask;

    private Task RefillAsync() =>
        //заправка
        Task.CompletedTask;
}
