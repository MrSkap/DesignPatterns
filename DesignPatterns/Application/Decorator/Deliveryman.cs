using Domain.Models;

namespace Application.Decorator;

/// <inheritdoc/>
public class Deliveryman : IDeliveryman
{
    /// <inheritdoc/>
    public async Task<bool> Deliver(Package package, string address)
    {
        try
        {
            await DeliverPackage(package, address);
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Can't deliver the package!");
        }
    }

    private async Task DeliverPackage(Package package, string address)
    {
        if (address == string.Empty)
        {
            throw new Exception("Address is empty");
        }

        if (package.Goods.Count == 0)
        {
            throw new Exception("Package is empty");
        }

        //Move to address and deliver package
        await Task.Delay(5000);
    }
}
