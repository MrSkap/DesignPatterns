namespace Application.Adapter;

/// <summary>
/// Путь.
/// </summary>
public record Route
{
    /// <summary>
    /// Адрес.
    /// </summary>
    public string Address { get; init; } = string.Empty;
}
