namespace Domain.Models;

/// <summary>
/// Товар.
/// </summary>
public class Good
{
    /// <summary>
    /// <see cref="GoodType"/>.
    /// </summary>
    public GoodType Type { get; set; } = GoodType.None;

    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; } = 0;

    /// <summary>
    /// <see cref="Size"/>.
    /// </summary>
    public Size Size { get; set; } = new();

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Вес.
    /// </summary>
    public float Weight { get; set; }
}
