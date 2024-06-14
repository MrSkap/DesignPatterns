using Domain.Models;

namespace Domain.Extensions;

/// <summary>
/// Расширение для размера <see cref="Size"/>.
/// </summary>
public static class SizeExtension
{
    /// <summary>
    /// Получить объем.
    /// </summary>
    /// <param name="size"><see cref="Size"/>.</param>
    /// <returns></returns>
    public static float GetVolume(this Size size) => size.Depth * size.Height * size.Width;

    /// <summary>
    /// Можно ли посместить в текущий объект указанный.
    /// </summary>
    /// <param name="owner">Текущий.</param>
    /// <param name="obj">Объект, который хотим поместить.</param>
    /// <returns></returns>
    public static bool CanBePlaced(this Size owner, Size obj) =>
        owner.Depth > obj.Depth &&
        owner.Height > obj.Height &&
        owner.Width > obj.Width;
}
