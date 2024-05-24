namespace Domain.Models;

/// <summary>
/// Возможные типы упаковки товаров.
/// </summary>
public enum FillingType
{
    /// <summary>
    /// По типу товара.
    /// </summary>
    ByGoodType,

    /// <summary>
    /// По равномерному распределению веса между всеми хранилищами.
    /// </summary>
    ByMiddleWeight,

    /// <summary>
    /// По максимальному использованию свободного места в хранилищах.
    /// </summary>
    ByMaxVolumeUsage,
}
