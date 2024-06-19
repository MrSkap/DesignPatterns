using Application.Command;

namespace Application.State;

/// <summary>
/// Состояние.
/// </summary>
public interface IState
{
    /// <summary>
    /// Обработать работы.
    /// </summary>
    /// <param name="jobs"><see cref="Job"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Handle(List<Job> jobs);
}
