using Domain.Models;

namespace Application.Proxy;

/// <summary>
/// Получает посылки от клиентов и отправляет их.
/// </summary>
public class ClientWorker
{
    private readonly IPostman _postman;
    private IEnumerable<Package> _sendingPackages = new List<Package>();

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="postman"></param>
    public ClientWorker(IPostman postman) => _postman = postman;

    /// <summary>
    /// Отдать работнику посылки.
    /// </summary>
    /// <param name="packages"></param>
    public void PutPackages(IEnumerable<Package> packages) => _sendingPackages = _sendingPackages.Concat(packages);

    /// <summary>
    /// Отправить посылки.
    /// </summary>
    public async Task SendPackages()
    {
        var state = await _postman.GetStateAsync();

        while (state != PostmanState.Awaiting)
        {
            await Task.Delay(5000);
            state = await _postman.GetStateAsync();
        }

        _postman.DeliverPackages(_sendingPackages);

        _sendingPackages = new List<Package>();
    }
}
