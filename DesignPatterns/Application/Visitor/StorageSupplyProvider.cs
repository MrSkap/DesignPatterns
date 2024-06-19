using Domain.Models;

namespace Application.Visitor;

/// <summary>
/// Предоставляет хранилища.
/// </summary>
public class StorageSupplyProvider : ProviderBase
{
    private StorageFilterOptions? _filterOptions;

    /// <inheritdoc/>
    public override Supply ProvideWithFiltering(ISupplyService service) => service.GetStoragesSupply(this);

    /// <inheritdoc/>
    public override Supply Provide()
    {
        //для получения поставки используется фильтрация
        return new()
        {
            Storages = new List<Storage>
            {
                new(),
            },
        };
    }

    /// <summary>
    /// Установить настройки фильтрации при получении
    /// </summary>
    /// <param name="options"><see cref="SetFilterOptions"/>.</param>
    public void SetFilterOptions(StorageFilterOptions options) => _filterOptions = options;
}
