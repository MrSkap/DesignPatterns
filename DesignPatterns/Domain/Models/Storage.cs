namespace Domain.Models;

/// <summary>
/// Хранилище.
/// </summary>
public class Storage
{
    /// <summary>
    /// <see cref="Goods"/>.
    /// </summary>
    public List<Good> Goods = new();

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

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
}
