using Application.Command;
using Serilog;

namespace Application.State;

/// <summary>
/// Состояние в процессе выполения работ.
/// </summary>
public class InProgressState : IState
{
    private readonly ILogger _logger = Log.ForContext<CompletedState>();

    /// <inheritdoc />
    public async Task Handle(List<Job> jobs)
    {
        _logger.Information("Start doing jobs");
        var tasks = jobs
            .Select(job => Task.Run(() => RunJob(job))).ToList();

        await Task.WhenAll(tasks);
        _logger.Information("Finish doing jobs");
    }

    private void RunJob(Job job)
    {
        if (job.State == JobState.NotStarted)
        {
            job.Execute();
        }
    }
}
