using Domain.Models;

namespace Application.Facade;

public class ManagerFacade
{
    private readonly Driver _driver = new();
    private Dictionary<Guid, int> _transportersPackagesCount = new();

    public void AddGoodForDelivering(List<Good> goods, string address)
    {
        var transporter = new GoodsTransporter();
        var packageId = Guid.NewGuid();
        transporter.AddPackages(new List<Package>(new[] { new Package(goods, packageId) }));
        _driver.AddAddresses(new[] { address }, transporter.Id);
    }

    private void RebalancePackages()
    {
        // look at transporters packages and balance them between each other
    }

    public void DeliveGoods() => _driver.Move(GetTransporter());

    private Guid GetTransporter() =>
        //get transporter id with the most count of goods
        Guid.NewGuid();
}
