namespace Application.Proxy;

/// <summary>
/// Доставщик новый и вынесенный отдельно.
/// </summary>
public class PostmanSystem
{
    /// <summary>
    /// Получить состояние доставщика.
    /// </summary>
    /// <param name="postmanId">Если нужен конкретный, можно указать его id.</param>
    /// <returns></returns>
    public Task<PostmanState> GetStateAsync(Guid? postmanId = null) => Task.FromResult(PostmanState.Awaiting);

    /// <summary>
    /// Начать доставку.
    /// </summary>
    /// <param name="request"><see cref="DeliveryRequest"/>.</param>
    /// <returns></returns>
    public async Task<Guid> StartDeliveryPackagesAsync(DeliveryRequest request)
    {
        //start working and return id of postman for tracking postman state
        await Task.Delay(1000);
        return Guid.NewGuid();
    }
}
