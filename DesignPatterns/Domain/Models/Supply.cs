namespace Domain.Models;

/// <summary>
/// Поставка.
/// </summary>
public class Supply
{
    public List<Storage> Storages { get; set; }
    public List<Good> Goods { get; set; }
}
