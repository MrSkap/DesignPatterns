namespace Application.Command;

/// <summary>
/// Команда.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Установить исполняемое действие.
    /// </summary>
    /// <param name="action">Действие.</param>
    void SetUp(Action action);

    /// <summary>
    /// Исполнить действие.
    /// </summary>
    /// <returns>Выполнилось успешно - true, неуспешно - false.</returns>
    bool Execute();
}
