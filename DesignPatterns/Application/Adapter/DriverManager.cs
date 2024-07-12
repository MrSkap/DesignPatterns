namespace Application.Adapter;

/// <summary>
/// Управляет водителями.
/// </summary>
public class DriverManager
{
    private List<IDriverAdapter> _driverAdapters = new();

    /// <summary>
    /// Получить водителей грузовиков.
    /// </summary>
    /// <param name="drivers"></param>
    public void SetLorryDrivers(IEnumerable<LorryDriverAdapter> drivers) => _driverAdapters = _driverAdapters.Concat(drivers).ToList();

    /// <summary>
    /// Получить водителей машин.
    /// </summary>
    /// <param name="drivers"></param>
    public void SetCarDrivers(IEnumerable<CarDriverAdapter> drivers) => _driverAdapters = _driverAdapters.Concat(drivers).ToList();

    /// <summary>
    /// Отправить всех в путь.
    /// </summary>
    public void MoveAllDrivers()
    {
        foreach (var driver in _driverAdapters)
        {
            driver.Move(new Route
            {
                Address = "Some address",
            });
        }
    }
}
