using Domain.Models;

namespace Application.Builder;

/// <summary>
/// Управляющий доставкой.
/// </summary>
public class DeliveryManager
{
    private readonly IDeliverWorkerBuilder _builder;
    private readonly List<IDeliverWorker> _workers = new();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="builder"><see cref="IDeliverWorkerBuilder"/>.</param>
    public DeliveryManager(IDeliverWorkerBuilder builder) => _builder = builder;

    /// <summary>
    /// Подготовить работников.
    /// </summary>
    /// <param name="configuration">Конфигурация.</param>
    public void PrepareWorkers(WorkersConfiguration configuration)
    {
        for (var i = 0; i < configuration.Count; i++)
        {
            var worker = _builder.Build()
                .AddRefill()
                .AddTarget(new Target("some address"))
                .AddGoodsLoading(new List<Good>())
                .AddTarget(new Target("some other address"))
                .AddGoodsUnloading(new List<Good>())
                .AddTarget(new Target("start address"))
                .Create();
            _workers.Add(worker);
        }
    }

    /// <summary>
    /// Отработать день.
    /// </summary>
    public async Task DoWorkDay()
    {
        var tasks = _workers.Select(worker => worker.StartWorkDay()).ToList();

        await Task.WhenAll(tasks);
    }
}
