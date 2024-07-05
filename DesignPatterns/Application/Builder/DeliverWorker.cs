using Serilog;

namespace Application.Builder;

/// <summary>
/// Доставщик.
/// </summary>
public class DeliverWorker : IDeliverWorker
{
    private readonly ILogger _logger = Log.ForContext<DeliverWorker>();

    /// <summary>
    /// Задачи доставщика.
    /// </summary>
    public readonly Queue<Func<Task>> Tasks = new();

    /// <summary>
    /// Начать рабочий день.
    /// </summary>
    public async Task StartWorkDay()
    {
        while (Tasks.TryDequeue(out var job))
        {
            _logger.Information("-> Start job");
            await job.Invoke();
            _logger.Information("<- Finish job");
        }
    }
}
