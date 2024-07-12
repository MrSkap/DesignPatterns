namespace Application.Adapter;

/// <summary>
/// Адаптер для водителя грузовика.
/// </summary>
public class LorryDriverAdapter : IDriverAdapter
{
    private readonly ILorryDriver _driver;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="driver"><see cref="ILorryDriver"/>.</param>
    public LorryDriverAdapter(ILorryDriver driver) => _driver = driver;

    /// <inheritdoc/>
    public void Move(Route route) =>
        _driver.Move(new LorryRote
        {
            Address = route.Address,
        });
}
