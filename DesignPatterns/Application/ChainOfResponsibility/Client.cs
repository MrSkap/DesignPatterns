using Domain.Models;

namespace Application.ChainOfResponsibility;

/// <summary>
/// Клиент по обработке товаров. Для примера использования цепочки обязанностей.
/// </summary>
public class Client
{
    private readonly HandlersOrganizer _organizer;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="organizer"><see cref="HandlersOrganizer"/>.</param>
    public Client(HandlersOrganizer organizer) => _organizer = organizer;

    /// <summary>
    /// Обработать товары.
    /// </summary>
    /// <param name="goods"><see cref="Good"/>.</param>
    public void ProcessGoods(IEnumerable<Good> goods)
    {
        var handler = _organizer.GetHandler();
        foreach (var good in goods)
        {
            handler.Handle(good);
        }
    }
}
