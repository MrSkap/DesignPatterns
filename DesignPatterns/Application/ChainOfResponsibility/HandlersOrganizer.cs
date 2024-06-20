namespace Application.ChainOfResponsibility;

/// <summary>
/// Формирует цепочку из обработчиков товаров.
/// </summary>
public class HandlersOrganizer
{
    /// <summary>
    /// Получить обработчика товаров.
    /// </summary>
    /// <returns></returns>
    public GoodsHandler GetHandler() =>
        new()
        {
            NextHandler = new FoodHandler()
            {
                NextHandler = new TechHandler(),
            },
        };
}
