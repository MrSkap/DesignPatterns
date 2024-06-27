using Application.Command;
using Serilog;

namespace Application.State;

/// <summary>
/// Не начатое состояние.
/// </summary>
public class NotStartedState : IState
{
    private readonly ILogger _logger = Log.ForContext<CompletedState>();

    /// <inheritdoc/>
    public Task Handle(List<Job> jobs)
    {
        _logger.Information("Not started state");
        _logger.Information("Get some jobs: {Jobs}", jobs);
        return Task.CompletedTask;
    }
}
