using Domain.Models;

namespace Application.Strategy.Fillers;

/// <summary>
/// Контекст заполнения.
/// </summary>
public class FillingContext
{
    /// <summary>
    /// <see cref="FillingType"/>.
    /// </summary>
    public FillingType Type { get; set; } = FillingType.ByMaxVolumeUsage;
}
