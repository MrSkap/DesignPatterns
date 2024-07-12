namespace Application.Facade;

public class Driver
{
    private readonly Dictionary<Guid, IEnumerable<string>> _clients = new();

    public void AddAddresses(IEnumerable<string> addresses, Guid id)
    {
        if (_clients.TryGetValue(id, out var clientsAddresses))
        {
            clientsAddresses = clientsAddresses.Concat(addresses);
            _clients[id] = clientsAddresses;
            return;
        }

        _clients.TryAdd(id, addresses);
    }

    public void Move(Guid clientId)
    {
        //some move action
        if (_clients.TryGetValue(clientId, out var clientsAddresses))
        {
            _clients[clientId] = Array.Empty<string>();
        }
    }
}
