using Serilog;

namespace Application.AbstractFactory;

/// <summary>
/// Обобщенная фабрика.
/// </summary>
public class GenericTransportFactory
{
    private readonly ILogger _logger = Log.ForContext<GenericTransportFactory>();

    /// <summary>
    /// Создать транспорт.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Create<T>()
        where T : AbstractTransport, new()
    {
        _logger.Information("Create transport of {}", typeof(T));
        return new T();
    }
}
