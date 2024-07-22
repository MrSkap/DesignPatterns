using Domain.Models;

namespace Application.Proxy;

/// <summary>
/// Заместитель доставщика.
/// </summary>
public class PostmanSystemProxy : IPostman
{
    private readonly DeliveryContext _context;
    private readonly PostmanSystem _system;
    private readonly Dictionary<Guid, PostmanState> _states = new();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="system"><see cref="PostmanState"/>.</param>
    /// <param name="context"><see cref="DeliveryContext"/>.</param>
    public PostmanSystemProxy(PostmanSystem system, DeliveryContext context)
    {
        _system = system;
        _context = context;
    }

    /// <inheritdoc/>
    public void DeliverPackages(IEnumerable<Package> packages)
    {
        var task = _system.StartDeliveryPackagesAsync(new DeliveryRequest(null, packages.ToList(), _context));
        task.Wait();
        var postman = task.Result;
        if (_states.ContainsKey(postman))
        {
            _states[postman] = PostmanState.Active;
        }
        else
        {
            _states.Add(postman, PostmanState.Active);
        }
    }

    /// <inheritdoc/>
    public async Task<PostmanState> GetStateAsync()
    {
        foreach (var state in _states)
        {
            _states[state.Key] = await _system.GetStateAsync(state.Key);
        }

        var freePostman = _states.Any(x => x.Value == PostmanState.Awaiting);
        return freePostman
            ? PostmanState.Awaiting
            : PostmanState.Active;
    }
}
