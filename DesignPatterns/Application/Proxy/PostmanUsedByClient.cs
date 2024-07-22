using Domain.Models;

namespace Application.Proxy;

/// <summary>
/// Доставщик, который изначально использовался с клиентом.
/// </summary>
public class PostmanUsedByClient : IPostman
{
    /// <inheritdoc/>
    public void DeliverPackages(IEnumerable<Package> packages)
    {
        // delive packages
    }

    /// <inheritdoc/>
    public Task<PostmanState> GetStateAsync() =>
        // analize postman system and return state
        Task.FromResult(PostmanState.Active);
}
