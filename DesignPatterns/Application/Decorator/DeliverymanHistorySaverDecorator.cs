using Domain.Models;

namespace Application.Decorator;

public class DeliverymanHistorySaverDecorator : DeliverymanDecorator
{
    private readonly List<DeliveryHistoryRow> _deliverHistory = new();
    private readonly IHistorySaver? _historySaver;

    /// <inheritdoc/>
    public DeliverymanHistorySaverDecorator(IDeliveryman deliveryman)
        : base(deliveryman)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="deliveryman"><see cref="IDeliveryman"/>.</param>
    /// <param name="historySaver"><see cref="IHistorySaver"/>.</param>
    public DeliverymanHistorySaverDecorator(IDeliveryman deliveryman, IHistorySaver? historySaver)
        : base(deliveryman) =>
        _historySaver = historySaver;

    /// <inheritdoc/>
    public override async Task<bool> Deliver(Package package, string address)
    {
        var result = await _deliveryman.Deliver(package, address);
        var historyRow = new DeliveryHistoryRow
        {
            Address = address,
            Id = Guid.NewGuid(),
            Package = package,
            Result = result,
        };
        _deliverHistory.Add(historyRow);
        if (_historySaver != null)
        {
            await _historySaver.Save(historyRow);
        }

        return result;
    }

    /// <summary>
    /// Получить всю накопленную историю.
    /// </summary>
    /// <returns></returns>
    public List<DeliveryHistoryRow> GetAllCollectHistoryRows() => _deliverHistory;
}
