namespace Application.Proxy;

/// <summary>
/// Состояния работы доставщика.
/// </summary>
public enum PostmanState
{
    /// <summary>
    /// Работает.
    /// </summary>
    Active,

    /// <summary>
    /// Ожидает.
    /// </summary>
    Awaiting,

    /// <summary>
    /// Нет информации.
    /// </summary>
    None,

    /// <summary>
    /// Сломан.
    /// </summary>
    Broken,
}
