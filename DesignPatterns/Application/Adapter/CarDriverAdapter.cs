namespace Application.Adapter;

public class CarDriverAdapter : IDriverAdapter
{
    private readonly ICarDriver _driver;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="driver"><see cref="ICarDriver"/>.</param>
    public CarDriverAdapter(ICarDriver driver) => _driver = driver;

    /// <inheritdoc/>
    public void Move(Route route) =>
        _driver.Move(new CarRoute
        {
            Address = route.Address,
        });
}
