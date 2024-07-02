namespace Application.AbstractFactory;

/// <summary>
/// Фабрика транспорта.
/// </summary>
public interface ITransportFactory
{
    /// <summary>
    /// Создать транспорт.
    /// </summary>
    /// <returns>Транспорт.</returns>
    AbstractTransport CreateTransport();
}
