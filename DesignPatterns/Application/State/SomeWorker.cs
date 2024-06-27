using Application.Command;

namespace Application.State;

/// <summary>
/// Работник.
/// </summary>
public class SomeWorker
{
    private IState _currentState;
    private readonly List<Job> _jobs = new();

    private readonly Dictionary<StateConstants, IState> _states = new()
    {
        { StateConstants.NotStarted, new NotStartedState() },
        { StateConstants.InProgress, new InProgressState() },
        { StateConstants.Completed, new CompletedState() },
    };

    /// <summary>
    /// Конструктор.
    /// </summary>
    public SomeWorker() => _currentState = _states[StateConstants.NotStarted];

    /// <summary>
    /// Получить работы.
    /// </summary>
    /// <param name="jobs"><see cref="Job"/>.</param>
    public void GetTasksAsync(IEnumerable<Job> jobs)
    {
        foreach (var task in jobs)
        {
            _jobs.Add(task);
        }
    }

    /// <summary>
    /// Начать работу
    /// Переход в состояние StateConstants.InProgress.
    /// </summary>
    public void Start() => _currentState = _states[StateConstants.InProgress];

    /// <summary>
    /// Выполнить имеющиеся работы.
    /// </summary>
    public async Task DoJobs() => await _currentState.Handle(_jobs);
}
