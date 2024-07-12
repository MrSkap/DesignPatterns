using Domain.Models;

namespace Application.Decorator;

/// <summary>
/// Декорирует <see cref="IDeliveryman"/>.
/// </summary>
public abstract class DeliverymanDecorator : IDeliveryman
{
    /// <summary>
    /// Доставщик.
    /// </summary>
    protected IDeliveryman _deliveryman;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="deliveryman"><see cref="IDeliveryman"/>.</param>
    public DeliverymanDecorator(IDeliveryman deliveryman) => _deliveryman = deliveryman;

    /// <inheritdoc/>
    public abstract Task<bool> Deliver(Package package, string address);
}
