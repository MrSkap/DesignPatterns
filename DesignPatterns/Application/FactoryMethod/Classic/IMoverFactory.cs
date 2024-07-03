using Application.FactoryMethod.Models;

namespace Application.FactoryMethod.Classic;

/// <summary>
/// Классическая реализация фабричного метода.
/// </summary>
public interface IMoverFactory
{
    /// <summary>
    /// Создать.
    /// </summary>
    /// <returns></returns>
    IMover Create();
}
