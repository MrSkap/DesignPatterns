namespace Domain.Models;

/// <summary>
/// Хранилище.
/// </summary>
public class Storage
{
    /// <summary>
    /// <see cref="Good"/>.
    /// </summary>
    public List<Good> Products = new();

    /// <summary>
    /// Объем хранилища.
    /// </summary>
    public float TotalVolume { get; set; } = 0;

    /// <summary>
    /// Свободное место.
    /// </summary>
    public float FreeVolume { get; set; } = 0;

    /// <summary>
    /// <see cref="Size"/>.
    /// </summary>
    public Size TotalSize { get; set; } = new();

    /// <summary>
    /// <see cref="Size"/>.
    /// </summary>
    public Size FreeSize { get; set; } = new();
}
