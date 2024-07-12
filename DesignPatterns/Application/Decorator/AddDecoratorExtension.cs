using Microsoft.Extensions.DependencyInjection;

namespace Application.Decorator;

/// <summary>
/// Расширение для добавления декоратора.
/// </summary>
public static class AddDecoratorExtension
{
    /// <summary>
    /// Добавить декоратор.
    /// </summary>
    /// <param name="collection"><see cref="IServiceCollection"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddDecorator(this IServiceCollection collection)
    {
        collection.AddTransient<IDeliveryman, DeliverymanHistorySaverDecorator>(provider =>
            new DeliverymanHistorySaverDecorator(
                new DeliverymanLoggerDecorator(
                    new Deliveryman()),
                provider.GetService<IHistorySaver>()));
        return collection;
    }
}
