using Serilog;

namespace Application.Command;

/// <summary>
/// Работа
/// </summary>
public class Job : ICommand
{
    private readonly ILogger _logger = Log.ForContext<Job>();
    private JobState _state;
    private Action _action = () => { };

    /// <summary>
    /// Состояние работы.
    /// </summary>
    public JobState State => _state;

    /// <inheritdoc />
    public void SetUp(Action action)
    {
        _action = action;
        _state = JobState.NotStarted;
    }

    /// <inheritdoc />
    public bool Execute()
    {
        try
        {
            _action.Invoke();
            _state = JobState.Completed;
            return true;
        }
        catch (Exception e)
        {
            _logger.Error(e, "Error in job");
            _state = JobState.Faulted;
            return false;
        }
    }
}
