namespace Application.Facade;

/// <summary>
/// Перевозчик.
/// </summary>
public class GoodsTransporter
{
    private List<Package> _packages = new();

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Добавить посылки.
    /// </summary>
    /// <param name="packages"></param>
    public void AddPackages(List<Package> packages) => _packages = _packages.Concat(packages).ToList();

    /// <summary>
    /// Выдать посылку.
    /// </summary>
    /// <param name="packageId">Идентификатор посылки.</param>
    /// <returns>Посылка.</returns>
    public Package? GetPackage(Guid packageId)
    {
        var package = _packages.Find(x => x.Id == packageId);
        if (package != null)
        {
            _packages.Remove(package);
        }

        return package;
    }

    /// <summary>
    /// Посылки у доставщика.
    /// </summary>
    /// <returns>Посылки.</returns>
    public IEnumerable<Package> GetAllPackagesInTransporter() => _packages;
}
