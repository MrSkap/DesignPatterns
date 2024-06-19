using Domain.Models;

namespace Application.Visitor;

/// <summary>
/// Настройки фильтрации хранилищ.
/// </summary>
public class StorageFilterOptions
{
    /// <summary>
    /// Максимальный размер.
    /// </summary>
    public Size? MaxSize { get; set; }

    /// <summary>
    /// Минимальный размер.
    /// </summary>
    public Size? MinSize { get; set; }
}
