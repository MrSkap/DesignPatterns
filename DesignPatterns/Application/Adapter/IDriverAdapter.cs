namespace Application.Adapter;

/// <summary>
/// Адаптер водителей.
/// </summary>
public interface IDriverAdapter
{
    /// <summary>
    /// Поехать.
    /// </summary>
    /// <param name="route">Путь.</param>
    void Move(Route route);
}
