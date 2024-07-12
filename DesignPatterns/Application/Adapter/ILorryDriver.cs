namespace Application.Adapter;

/// <summary>
/// Водитель грузовика.
/// </summary>
public interface ILorryDriver
{
    /// <summary>
    /// Поехать.
    /// </summary>
    /// <param name="route">Путь.</param>
    void Move(LorryRote route);
}
