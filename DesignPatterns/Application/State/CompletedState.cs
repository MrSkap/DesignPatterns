using Application.Command;
using Serilog;

namespace Application.State;

/// <summary>
/// Завеошенное состояние.
/// </summary>
public class CompletedState : IState
{
    private ILogger _logger = Log.ForContext<CompletedState>();

    /// <inheritdoc />
    public Task Handle(List<Job> jobs)
    {
        var dictionary = jobs.GroupBy(x => x.State).ToDictionary(x => x.Key);
        _logger.Information("Completed: {CompletedCount} \n Failed: {FailedCount} \n Not started: {NotStartedCount}",
            dictionary[JobState.Completed].Count(),
            dictionary[JobState.Faulted].Count(),
            dictionary[JobState.NotStarted].Count());
        return Task.CompletedTask;
    }
}
