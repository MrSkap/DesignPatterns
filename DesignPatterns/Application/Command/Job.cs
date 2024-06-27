using Serilog;

namespace Application.Command;

/// <summary>
/// Работа
/// </summary>
public class Job : ICommand
{
    private readonly ILogger _logger = Log.ForContext<Job>();
    private Action _action = () => { };

    /// <summary>
    /// Состояние работы.
    /// </summary>
    public JobState State { get; private set; }

    /// <inheritdoc/>
    public void SetUp(Action action)
    {
        _action = action;
        State = JobState.NotStarted;
    }

    /// <inheritdoc/>
    public bool Execute()
    {
        try
        {
            _action.Invoke();
            State = JobState.Completed;
            return true;
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error in job");
            State = JobState.Faulted;
            return false;
        }
    }
}
