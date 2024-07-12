using Domain.Models;
using Serilog;

namespace Application.Decorator;

/// <summary>
/// Логирует доставку и устойчив к ошибкам.
/// </summary>
public class DeliverymanLoggerDecorator : DeliverymanDecorator
{
    private readonly ILogger _logger = Log.ForContext<DeliverymanLoggerDecorator>();

    /// <inheritdoc/>
    public DeliverymanLoggerDecorator(IDeliveryman deliveryman)
        : base(deliveryman)
    {
    }

    /// <inheritdoc/>
    public override async Task<bool> Deliver(Package package, string address)
    {
        _logger.Information("Start to deliver Package {Id}!", package.Id);
        _logger.Debug("Deliver package {Id} with {Count} goods", package.Id, package.Goods.Count);

        try
        {
            await _deliveryman.Deliver(package, address);
            return true;
        }
        catch (Exception e)
        {
            _logger.Error(e, "Fail to deliver package");
            return false;
        }
        finally
        {
            _logger.Information("Complete to deliver package {Id}", package.Id);
        }
    }
}
