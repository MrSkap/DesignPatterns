namespace Application.Command;

/// <summary>
/// Состояние работы.
/// </summary>
public enum JobState
{
    /// <summary>
    /// Не началось.
    /// </summary>
    NotStarted,

    /// <summary>
    /// Завершена.
    /// </summary>
    Completed,

    /// <summary>
    /// Завершилась с ошибкой.
    /// </summary>
    Faulted,
}
